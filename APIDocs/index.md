---
_layout: landing
---

# NVAPIWrapper API Docs

Welcome to the generated API reference for **NVAPIWrapper**, a C# facade over the NVIDIA NVAPI SDK. Use this site to explore the public classes, helpers, and DTOs that make up the wrapper.

The goal of NVAPIWrapper project is to provide a lightweight, simpler way to access the NVIDIA NVAPI API, to read settings and make changes to the NVIDIA GPU settings on a PC. The NVAPIWrapper project provides Helper objects that provide a pointer-free, simple ergonomic API surface to make it easy to use, and it still exposes the native handles if you need to do something advanced.

## How to use

- Start at the API landing page: [NVAPIWrapper API Reference](/api/NVAPIWrapper.html).
- Navigate by feature: helpers like `NVAPIDisplayHelper` and `NVAPIPhysicalGpuHelper` list the available operations and event hooks.
- Facade helpers return DTOs.

## Where to Learn More

- **Project overview & usage**: See `README.md` at the repository root or the repo at https://github.com/terrymacdonald/NVAPIWrapper for quick-start examples and patterns.
- **NVAPI SDK reference**: The upstream NVAPI SDK official docs are at https://docs.nvidia.com/gameworks/content/gameworkslibrary/coresdk/nvapi/index.html.
- **NVAPI SDK repository**: The upstream NVAPI SDK repository is at https://github.com/NVIDIA/nvapi. Samples provided by NVIDIA are available at `..\nvapi\Samples`.
- **NVAPIWrapper Samples**: Runnable samples demonstrating display, desktop, GPU, and event-listener flows are under `Sample_Code/`.

## Regenerating Docs

Use `./refresh_nvapi_api_docs.ps1` from the repo root to rebuild the DocFX site and serve it locally on port 8000.
