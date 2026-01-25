# NVAPIWrapper Build Plan (Detailed)

## Goal
Create a robust C# wrapper for NVIDIA NVAPI that mirrors the structure and quality of IGCLWrapper, using ClangSharpPInvokeGenerator for native bindings, and providing both native and facade-level APIs with comprehensive tests and documentation.

## Guiding Constraints (from AGENTS.md)
- Always propose a plan before editing; only edit after approval.
- Do not hand-edit `cs_generated/`; only change via `ClangSharpConfig.rsp`.
- Native APIs must be developed/tested before facade APIs.
- Use NVAPI samples and headers as the source of truth.
- Respect handle invalidation rules and struct version initialization macros.
- Ensure graceful handling of missing hardware or optional features via test skips.
- PowerShell-only scripts; Windows 11 x64 assumptions.

## Phase 0: Baseline Recon and Parity With IGCLWrapper
Objective: Understand the IGCLWrapper patterns and ensure NVAPIWrapper mirrors the same structure and conventions.

Steps:
1) Review IGCLWrapper solution layout:
   - `IGCLWrapper.sln`, project structure, test suite split, samples.
2) Review key IGCLWrapper patterns:
   - `IGCLApi` + `IGCLApiHelper`, SafeHandle usage, enum/struct DTOs.
   - Native tests vs facade tests patterns and naming.
3) Review IGCLWrapper build/test scripts and versioning:
   - `build_igcl.ps1`, `test_igcl.ps1`, `create_igcl_release_zip.ps1`.
4) Capture these patterns to apply to NVAPIWrapper.

Deliverable:
- A concise checklist of the patterns we will replicate in NVAPIWrapper.

## Phase 1: NVAPI SDK Surface Mapping
Objective: Map what needs to be generated and how NVAPI resolves functions.

Steps:
1) Identify SDK entry points and lookup mechanism:
   - Confirm `NvAPI_QueryInterface` usage and signature.
   - Use `nvapi\nvapi_interface.h` as the list of function IDs.
2) Identify key headers to include in generation:
   - `nvapi.h`, `nvapi_lite_*.h`, and any related include dependencies.
3) Note struct/version macros and handle behaviors from docs.
4) Identify differences between NVAPI and IGCL that will be required due to the difference in NVAPI from IGCL and report that to the user for confirmation.

Deliverable:
- A list of input headers + include paths.
- A concrete plan for function lookup (ID → function pointer).

## Phase 2: ClangSharp Generation Setup
Objective: Set up generation config and csproj integration.

Steps:
1) Create `NVAPIWrapper/ClangSharpConfig.rsp` modeled after IGCLWrapper:
   - Input headers, include paths.
   - Output namespace, output dir, method class name.
   - Options: `multi-file`, `generate-doc-includes`, `generate-helper-types`, `generate-macro-bindings`, `latest-codegen`, `windows-types`, `generate-tests-xunit`.
2) Create `NVAPIWrapper/NVAPIWrapper.csproj` and integrate:
   - `ClangSharpPInvokeGenerator` ItemGroup.
   - `GenerateFromClangSharp` target to call generator.
   - `CleanClangSharpGenerated` target to clear generated output.
3) Remove or replace placeholder `ClangSharpPInvokeGeneratorOptions.txt`.

Deliverable:
- A working ClangSharp generation pipeline for NVAPI.

## Phase 3: Native Layer (Core API)
Objective: Implement the core native wrapper and DLL loader.

Steps:
1) Implement `NVAPINative`:
   - Load `nvapi64.dll` via `LoadLibraryEx`.
   - Resolve `NvAPI_QueryInterface`.
2) Implement `NVAPIApi`:
   - `Initialize()` uses `NvAPI_Initialize`.
   - Clean disposal via `NvAPI_Unload`.
   - `IsNVAPIDllAvailable` and error message support.
   - Handle `NVAPI_ALREADY_INITIALIZED` gracefully.
3) Implement function lookup:
   - Build an internal map of IDs from `nvapi_interface.h`.
   - Provide `TryGetFunctionPointer(id)` and availability checks.
4) Implement minimal helpers for enum/handle retrieval:
   - `EnumeratePhysicalGPUs`, `EnumerateLogicalGPUs`, display handle enumeration.
   - Keep strict native-level semantics.

Deliverable:
- `NVAPIApi` and `NVAPINative` with QueryInterface-based function resolution.

## Phase 4: Native Tests
Objective: Validate that generated bindings and core native API are correct.

Steps:
1) Add native tests for:
   - DLL availability
   - Initialization/unload
   - Enumerations of GPUs/displays
2) Use hardware-aware gating:
   - Skip on missing GPU, missing DLL, or unsupported features.
3) Keep tests focused on raw generated API only (no facade calls).

Deliverable:
- `NVAPIWrapper.NativeTests` test suite aligned with AGENTS.md rules.

## Phase 5: Facade Layer
Objective: Provide safe, ergonomic wrappers around native APIs.

Steps:
1) Implement `NVAPIApiHelper` and helper factories.
2) Build helper classes per feature group:
   - Maintain naming and layout patterns.
3) Implement DTOs for data structures:
   - Convert native structs to managed DTOs.
   - Ensure proper struct size/version setup.
4) Implement safe lifetime handling:
   - Dispose properly; use exceptions on disposed usage.

Deliverable:
- `NVAPIApiHelper` and feature helpers with DTOs.

## Phase 6: Facade Tests
Objective: Verify facade ergonomics and ensure native correctness via high-level flows.

Steps:
1) Add facade tests for each feature area.
2) Gate optional features by supported flags or error codes.
3) Keep tests read-only, non-tuning, and hardware-aware.

Deliverable:
- `NVAPIWrapper.FacadeTests` suite with clear, feature-scoped tests.

## Phase 7: Samples and Documentation
Objective: Provide user guidance and example usage.

Steps:
1) Implement sample apps in `Samples/`:
   - GPU enumeration, display info, temperature, etc.
2) Update `README.md` to match actual API surface.
3) Align scripts and doc comments to match NVAPI usage patterns.

Deliverable:
- Updated README and sample projects.

## Phase 8: Release Packaging and Validation
Objective: Ensure scripts and versioning match expected release flow.

Steps:
1) Validate `build_nvapi.ps1`, `test_nvapi.ps1`, `create_nvapi_release_zip.ps1`.
2) Confirm `VERSION` and git-count patching works as expected.
3) Final smoke test on a Windows 11 x64 machine with NVIDIA drivers.

Deliverable:
- Verified build/test/release scripts and ready-for-release artifacts.

## Current Status
- Phase 0 and Phase 1 are complete.
- Phase 2 is complete (ClangSharp config, shim header, csproj wiring, and solution scaffolding).
- Phase 3 is in progress (NVAPINative loader, NVAPIApi initialization/unload, NVAPIException, and function availability map added).
- Phase 4 started with BasicApiTests in `NVAPIWrapper.NativeTests`.
- AGENTS.md updated to align with NVAPI concepts and paths.

## Next Action
Begin Phase 3 by confirming the `NvAPI_QueryInterface` entrypoint signature and implementing the core native loader (`NVAPINative`) and `NVAPIApi` initialization/unload flow.
