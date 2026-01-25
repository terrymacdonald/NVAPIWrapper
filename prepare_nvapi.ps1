# Enhanced NVAPI Preparation Script with Improved Error Handling


# Get the directory where this script is located (works from any location)
$scriptRoot = $PSScriptRoot
if (-not $scriptRoot) {
    $scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
}

# Change to script directory to ensure relative paths work correctly
Set-Location $scriptRoot
Write-Host "Working directory: $scriptRoot" -ForegroundColor Cyan
Write-Host ""

# Define NVAPI-related variables
$zipUrl = "https://github.com/NVIDIA/nvapi/archive/refs/heads/main.zip"
$zipFilePath = Join-Path $scriptRoot "nvapi-main.zip"
$destinationFolder = Join-Path $scriptRoot "nvapi"
$tempExtractFolder = Join-Path $scriptRoot "nvapi-master"
$outFolder = Join-Path $scriptRoot "out"

# Function to validate NVAPI SDK completeness
function Test-NVAPISDKCompleteness {
    param([string]$NVAPIPath)
    
    $requiredPaths = @(
        "$NVAPIPath\amd64\nvapi64.lib",
        "$NVAPIPath\nvapi.h"
    )
    
    $missingFiles = @()
    foreach ($path in $requiredPaths) {
        if (-not (Test-Path -Path $path)) {
            $missingFiles += $path
        }
    }
    
    if ($missingFiles.Count -gt 0) {
        Write-Host "ERROR: NVAPI SDK is incomplete. Missing files:" -ForegroundColor Red
        foreach ($file in $missingFiles) {
            Write-Host "  - $file" -ForegroundColor Red
        }
        return $false
    }
    
    Write-Host "NVAPI SDK validation passed - all required files present." -ForegroundColor Green
    return $true
}

# Function to check internet connectivity
function Test-InternetConnection {
    try {
        $response = Invoke-WebRequest -Uri "https://www.google.com" -Method Head -TimeoutSec 10 -ErrorAction Stop
        return $true
    } catch {
        return $false
    }
}

# ============================================================================
# Main Script Execution
# ============================================================================

Write-Host "=== Enhanced NVAPI Preparation Script ===" -ForegroundColor Cyan
Write-Host "Preparing NVAPI SDK ..." -ForegroundColor Cyan

# ============================================================================
# Check .NET 10.0 SDK (informational only)
# ============================================================================
Write-Host "Checking for .NET 10.0 SDK..." -ForegroundColor Yellow

$dotnetInstalled = $false
$net10Installed = $false

try {
    $dotnetPath = Get-Command dotnet -ErrorAction SilentlyContinue
    if ($dotnetPath) {
        $dotnetInstalled = $true
        $sdks = & dotnet --list-sdks 2>&1
        $net10Sdk = $sdks | Where-Object { $_ -match "10\.0\." }
        
        if ($net10Sdk) {
            $net10Installed = $true
            Write-Host ".NET 10.0 SDK found:" -ForegroundColor Green
            $net10Sdk | ForEach-Object { Write-Host "  $_" -ForegroundColor Green }
        } else {
            Write-Host ".NET CLI found, but .NET 10.0 SDK not installed" -ForegroundColor Yellow
            Write-Host "Available SDKs:" -ForegroundColor Gray
            $sdks | ForEach-Object { Write-Host "  $_" -ForegroundColor Gray }
        }
    } else {
        Write-Host ".NET CLI not found in PATH" -ForegroundColor Yellow
    }
} catch {
    Write-Host "Could not check .NET installation: $_" -ForegroundColor Yellow
}

if (-not $net10Installed) {
    Write-Host ""
    Write-Host "??  WARNING: .NET 10.0 SDK not detected" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "To build this project, you need:" -ForegroundColor Yellow
    Write-Host "  - .NET 10.0 SDK" -ForegroundColor Cyan
    Write-Host "  - Download from: https://dotnet.microsoft.com/download/dotnet/10.0" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Or install via Visual Studio:" -ForegroundColor Yellow
    Write-Host "  - Open Visual Studio Installer" -ForegroundColor Cyan
    Write-Host "  - Modify your installation" -ForegroundColor Cyan
    Write-Host "  - Under 'Individual components', select '.NET 10.0 Runtime'" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Continuing with ADLX SDK download..." -ForegroundColor Gray
    Write-Host ""
}

Write-Host ""

# Check internet connection
Write-Host "Checking internet connectivity..."
if (-not (Test-InternetConnection)) {
    Write-Host "ERROR: No internet connection detected." -ForegroundColor Red
    Write-Host "This script requires internet access to download the ADLX SDK." -ForegroundColor Red
    exit 1
}
Write-Host "Internet connection verified." -ForegroundColor Green
Write-Host ""

# ============================================================================
# ClangSharpPInvokeGenerator Nuget Install
# ============================================================================
Write-Host "=== Installing ClangSharpPInvokeGenerator Nuget Package ===" -ForegroundColor Cyan

if ($net10Installed) {
    Write-Host "Running dotnet tool installer" -ForegroundColor Green
    dotnet tool install --global ClangSharpPInvokeGenerator
} else {
    Write-Host "Skipping ClangSharpPInvokeGenerator installation (requires .NET 10.0 SDK)" -ForegroundColor Yellow
}
Write-Host ""

# ============================================================================
# Docfx Nuget Install
# ============================================================================
Write-Host "=== Installing Docfx Nuget Package ===" -ForegroundColor Cyan

if ($net10Installed) {
    Write-Host "Running dotnet tool installer" -ForegroundColor Green
    dotnet tool install -g docfx
} else {
    Write-Host "Skipping Docfx installation (requires .NET 10.0 SDK)" -ForegroundColor Yellow
}
Write-Host ""


# ============================================================================
# NVAPI SDK Download
# ============================================================================
Write-Host ""
Write-Host "=== NVAPI SDK Dependency Check ===" -ForegroundColor Cyan

# Check if NVAPI folder already exists and is complete
if (Test-Path -Path $destinationFolder) {
    Write-Host "Existing drivers.gpu.control-library folder found. Validating completeness..."
    if (Test-NVAPISDKCompleteness -NVAPIPath $destinationFolder) {
        Write-Host "Existing NVAPI SDK is complete. Skipping download." -ForegroundColor Green
        
        Write-Host "Project pre-build tasks completed successfully." -ForegroundColor Green
        exit 0
    } else {
        Write-Host "Existing NVAPI SDK is incomplete. Re-downloading..." -ForegroundColor Yellow
        try {
            Remove-Item -Path $destinationFolder -Recurse -Force -ErrorAction Stop
            Write-Host "Removed incomplete NVAPI folder." -ForegroundColor Green
        } catch {
            Write-Host "ERROR: Failed to remove existing NVAPI folder: $_" -ForegroundColor Red
            exit 1
        }
    }
}

# Download the zip file
Write-Host "Downloading the latest version of NVAPI... (may take a while)"
try {
    # Add progress tracking for large downloads
    $ProgressPreference = 'Continue'
    Invoke-WebRequest -Uri $zipUrl -OutFile $zipFilePath -ErrorAction Stop
    Write-Host "Download succeeded." -ForegroundColor Green
    
    # Validate downloaded file
    if (-not (Test-Path -Path $zipFilePath)) {
        throw "Downloaded file not found"
    }
    
    $fileSize = (Get-Item $zipFilePath).Length
    if ($fileSize -lt 100KB) {
        throw "Downloaded file appears to be too small ($fileSize bytes)"
    }
    
    Write-Host "Downloaded file validated ($([math]::Round($fileSize/100KB, 2)) KB)." -ForegroundColor Green
    
} catch {
    Write-Host "ERROR: Failed to download NVAPI SDK: $_" -ForegroundColor Red
    # Clean up partial download
    if (Test-Path -Path $zipFilePath) {
        Remove-Item -Path $zipFilePath -Force
    }
    exit 1
}

# Unzip the downloaded file into a temporary folder
Write-Host "Extracting the contents of the zip file... (may take a while)"
try {
    Expand-Archive -Path $zipFilePath -DestinationPath . -Force -ErrorAction Stop
    Write-Host "Extraction completed successfully." -ForegroundColor Green
} catch {
    Write-Host "ERROR: Failed to extract NVAPI SDK: $_" -ForegroundColor Red
    # Clean up
    if (Test-Path -Path $zipFilePath) {
        Remove-Item -Path $zipFilePath -Force
    }
    exit 1
}

# Validate extracted folder exists
if (-not (Test-Path -Path $tempExtractFolder)) {
    Write-Host "ERROR: Extracted folder '$tempExtractFolder' not found." -ForegroundColor Red
    # Clean up
    if (Test-Path -Path $zipFilePath) {
        Remove-Item -Path $zipFilePath -Force
    }
    exit 1
}

# Rename the temp folder to final destination
Write-Host "Renaming drivers.gpu.control-library-main to drivers.gpu.control-library..."
try {
    Rename-Item -Path $tempExtractFolder -NewName $destinationFolder -ErrorAction Stop
    Write-Host "Folder renamed successfully." -ForegroundColor Green
} catch {
    Write-Host "ERROR: Failed to rename NVAPI folder: $_" -ForegroundColor Red
    # Clean up
    if (Test-Path -Path $zipFilePath) {
        Remove-Item -Path $zipFilePath -Force
    }
    if (Test-Path -Path $tempExtractFolder) {
        Remove-Item -Path $tempExtractFolder -Recurse -Force
    }
    exit 1
}

# Validate NVAPI SDK completeness
Write-Host "Validating NVAPI SDK completeness..."
if (-not (Test-NVAPISDKCompleteness -NVAPIPath $destinationFolder)) {
    Write-Host "ERROR: Downloaded NVAPI SDK is incomplete." -ForegroundColor Red
    # Clean up
    if (Test-Path -Path $zipFilePath) {
        Remove-Item -Path $zipFilePath -Force
    }
    if (Test-Path -Path $destinationFolder) {
        Remove-Item -Path $destinationFolder -Recurse -Force
    }
    exit 1
}

# Remove the zip file after successful extraction and validation
Write-Host "Cleaning up download files..."
try {
    Remove-Item -Path $zipFilePath -Force -ErrorAction Stop
    Write-Host "Cleanup completed." -ForegroundColor Green
} catch {
    Write-Host "WARNING: Failed to remove zip file: $_" -ForegroundColor Yellow
    # This is not critical, continue
}

Write-Host ""
Write-Host "=== NVAPI SDK Setup Complete ===" -ForegroundColor Green
Write-Host ""
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  - NVAPI SDK location: $destinationFolder" -ForegroundColor Cyan
Write-Host ""


if ($net10Installed) {
    Write-Host "Next steps:" -ForegroundColor Green
    Write-Host "  - Build the wrapper: .\build_nvapi.ps1" -ForegroundColor Gray
    Write-Host "  - Or open NVAPIWrapper.sln in Visual Studio" -ForegroundColor Gray
    Write-Host "  - Or use: dotnet build" -ForegroundColor Gray
} else {
    Write-Host "Before building:" -ForegroundColor Yellow
    Write-Host "  1. Install .NET 10.0 SDK from: https://dotnet.microsoft.com/download/dotnet/10.0" -ForegroundColor Cyan
    Write-Host "     Or via Visual Studio Installer (see warning above)" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Then build:" -ForegroundColor Green
    Write-Host "  - .\build_nvapi.ps1" -ForegroundColor Gray
    Write-Host "  - Or open NVAPIWrapper.sln in Visual Studio" -ForegroundColor Gray
}
Write-Host ""

