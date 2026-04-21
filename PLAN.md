# NVAPIWrapper DTO RawData Refactor Plan

## STATUS KEY
- `[ ]` = Not started
- `[~]` = In progress
- `[x]` = Done

---

## OBJECTIVE
Replace all `byte[] RawData` properties in DTOs inside `NVAPIWrapper/NVAPIPhysicalGpuHelper.cs` with explicit typed properties for each field of the underlying native struct. Each DTO must be updated with:
1. New constructor accepting explicit fields (no byte[] parameter)
2. `FromNative(nativeStruct)` reading each field individually
3. `ToNative()` reconstructing the native struct from properties
4. `Equals()` comparing fields directly (not byte sequences)
5. `GetHashCode()` hashing individual fields
6. XML `<summary>` docs on each new property
7. `CreateDefault()` unchanged pattern (uses version constant)
8. Any needed sub-DTOs created alongside the parent DTO

**File being edited:** `NVAPIWrapper/NVAPIPhysicalGpuHelper.cs`
**Tests to update after each DTO:** `NVAPIWrapper.FacadeTests/NVAPIPhysicalGpuHelperFacadeTests.cs`

**Build check after each DTO:** `dotnet build NVAPIWrapper/NVAPIWrapper.csproj`

---

## RULES TO REMEMBER
- Do NOT edit cs_generated files; only read them for type information.
- For reserved/rsvd fields: skip them entirely (do not expose as properties).
- For bitfield booleans (e.g. `bIsEditable: 1`): expose as `bool` property, use `!= 0` in FromNative and `? 1u : 0u` in ToNative.
- For fixed byte arrays used as strings: expose as `string` (use `NVAPIStringHelper` or `Encoding.ASCII.GetString` stripped of nulls).
- For fixed byte arrays that are reserved: skip them.
- For union types in sub-DTOs: expose each named union member as a typed property, plus a `byte[]` `RawData` spanning the union's full byte footprint. Do NOT try to decompose union variants further.
- For pointer fields (unsafe struct members): the helper method must dereference the pointer at call time and populate an array; the DTO stores the materialized array, never a pointer.
- Preserve `CreateDefault()` exactly — it must still set the correct version constant.
- All new properties must have XML `<summary>` docs.

---

## TASK LIST

### GROUP A — Flat structs (no sub-DTOs needed)

---

#### [x] 1. NVAPIGpuVirtualizationInfoDto (line ~3464)
**Native struct:** `_NV_GPU_VIRTUALIZATION_INFO`
**Fields to expose:**
- `VirtualizationMode` → `_NV_VIRTUALIZATION_MODE virtualizationMode` (enum, keep as-is)

**Constructor:** `NVAPIGpuVirtualizationInfoDto(_NV_VIRTUALIZATION_MODE virtualizationMode)`
**FromNative:** read `native.virtualizationMode`
**ToNative:** set `version` + `virtualizationMode`
**Notes:** `reserved` field — skip (it's padding). Version comes from `CreateDefault()` via constant. In `ToNative()`, read the version from the constant since it is not stored.

---

#### [x] 2. NVAPIEncoderStatisticsDto (line ~3540)
**Native struct:** `_NV_ENCODER_STATISTICS_V1`
**Fields to expose:**
- `SessionsCount` → `uint sessionsCount`
- `AverageFps` → `uint averageFps`
- `AverageLatency` → `uint averageLatency`

**Constructor:** `NVAPIEncoderStatisticsDto(uint sessionsCount, uint averageFps, uint averageLatency)`
**FromNative:** read three fields
**ToNative:** set `version` + three fields

---

#### [x] 3. NVAPIGpuVrReadyDto (line ~3616)
**Native struct:** `_NV_GPU_VR_READY_V1`
**Fields to expose:**
- `IsVRReady` → `bool` from bitfield `isVRReady : 1`

**Constructor:** `NVAPIGpuVrReadyDto(bool isVRReady)`
**FromNative:** `native.isVRReady != 0`
**ToNative:** set `version`, `_bitfield` via `isVRReady ? 1u : 0u`

---

#### [x] 4. NVAPIGpuGspInfoDto (line ~3654)
**Native struct:** `_NV_GPU_GSP_INFO_V1`
**Fields to expose:**
- `FirmwareVersion` → `string` decoded from `firmwareVersion` (`byte[64]` fixed buffer, null-terminated ASCII)

**Constructor:** `NVAPIGpuGspInfoDto(string firmwareVersion)`
**FromNative:** decode bytes to string: `System.Text.Encoding.ASCII.GetString(span).TrimEnd('\0')`
**ToNative:** encode string back to byte[64] fixed buffer, pad with zeros
**Notes:** `reserved` field — skip.

---

#### [x] 5. NVAPINvLinkCapsDto (line ~3692)
**Native struct:** `NVLINK_GET_CAPS_V1`
**Fields to expose:**
- `CapsTbl` → `uint capsTbl`
- `LowestNvlinkVersion` → `byte lowestNvlinkVersion`
- `HighestNvlinkVersion` → `byte highestNvlinkVersion`
- `LowestNciVersion` → `byte lowestNciVersion`
- `HighestNciVersion` → `byte highestNciVersion`
- `LinkMask` → `uint linkMask`

**Constructor:** 6-parameter constructor with all above
**FromNative/ToNative:** straightforward field copy

---

### GROUP B — Structs with sub-DTO arrays

---

#### [x] 6. NVAPIGpuPerfPstates20InfoDto (line ~3426)
**Native struct:** `_NV_GPU_PERF_PSTATES20_INFO_V2`
**Top-level fields to expose:**
- `IsEditable` → `bool` from `bIsEditable : 1`
- `NumPstates` → `uint numPstates`
- `NumClocks` → `uint numClocks`
- `NumBaseVoltages` → `uint numBaseVoltages`
- `Pstates` → `NVAPIGpuPerfPstateDto[]` (array of 16, read from `pstates`)
- `OvNumVoltages` → `uint` from `ov.numVoltages`
- `OvVoltages` → `NVAPIGpuPerfVoltageDto[]` (from `ov.voltages` fixed array)

**Sub-DTO needed: `NVAPIGpuPerfPstateDto`**
The `pstates` member is `_pstates_e__Struct[16]` (NOT a fixed buffer — it's a partial struct inside the fixed buffer).
**Fields from `_pstates_e__Struct`:**
- `PstateId` → `_NV_GPU_PERF_PSTATE_ID pstateId`
- `IsEditable` → `bool bIsEditable : 1`
- `Clocks` → `NVAPIGpuPerfClockEntryDto[]` (need to inspect sub-struct)
- `BaseVoltages` → `NVAPIGpuPerfVoltageEntryDto[]` (need to inspect sub-struct)
  
**WARNING:** `_NV_GPU_PERF_PSTATES20_INFO_V2.pstates` is stored as `_pstates_e__FixedBuffer` and the inner struct `_pstates_e__Struct` contains more inline arrays. Before coding this DTO, re-read:
- `_NV_GPU_PERF_PSTATES20_INFO_V2.cs` in full
- Inner struct types for clocks and voltages
This DTO is the most complex. Tackle LAST within this group.

---

#### [x] 7. NVAPILicensableFeaturesDto (line ~3502)
**Native struct:** `_NV_LICENSABLE_FEATURES_V4`
**Top-level fields to expose:**
- `IsLicenseSupported` → `bool` from `isLicenseSupported : 1`
- `LicensableFeatureCount` → `uint licensableFeatureCount`
- `Signature` → `string` decoded from `signature` (`byte[128]`, null-terminated ASCII)
- `LicenseDetails` → `NVAPILicenseFeatureDetailsDto[]` (array of 3)

**Sub-DTO needed: `NVAPILicenseFeatureDetailsDto`** wrapping `_NV_LICENSE_FEATURE_DETAILS_V4`
**Fields:**
- `IsEnabled` → `bool` from `isEnabled : 1`
- `IsFeatureEnabled` → `bool` from `isFeatureEnabled : 1`
- `FeatureCode` → `_NV_LICENSE_FEATURE_TYPE featureCode` (enum)
- `LicenseInfo` → `string` decoded from `licenseInfo` (`NvAPI_LicenseString` = `sbyte[128]`)
- `ProductName` → `string` decoded from `productName` (`sbyte[128]`)
- `LicenseExpiry` → `_NV_LICENSE_EXPIRY_DETAILS licenseExpiry` (expose as-is, it's a small struct)

**Note on string decoding for sbyte[]:** Use `System.Text.Encoding.ASCII.GetString(MemoryMarshal.Cast<sbyte, byte>(span)).TrimEnd('\0')`

---

#### [x] 8. NVAPIEncoderSessionsInfoDto (line ~3578)
**Native struct:** `_NV_ENCODER_SESSIONS_INFO_V1` — **has unsafe pointer `pSessionInfo`**
**Special handling required:** The native struct holds `NvU32 sessionsCount` and `_NV_ENCODER_PER_SESSION_INFO_V1* pSessionInfo`.  
The current RawData byte-copy approach is **broken** for this struct since it captures the pointer address, not the pointed data.

**Fix plan:**
1. Update `GetEncoderSessionsInfo()` in `NVAPIPhysicalGpuHelper` (the helper method, not cs_generated) to dereference `pSessionInfo` at call time using `Span<_NV_ENCODER_PER_SESSION_INFO_V1>`.
2. Change `NVAPIEncoderSessionsInfoDto.FromNative()` to accept both the struct AND a `NVAPIEncoderPerSessionInfoDto[]` array built at call time.

**Top-level fields:**
- `SessionsCount` → `uint sessionsCount`
- `Sessions` → `NVAPIEncoderPerSessionInfoDto[]`

**Sub-DTO needed: `NVAPIEncoderPerSessionInfoDto`** wrapping `_NV_ENCODER_PER_SESSION_INFO_V1`
**Fields:**
- `SessionId` → `uint sessionId`
- `ProcessId` → `uint processId`
- `VgpuInstance` → `uint vgpuInstance`
- `CodecType` → `_NV_ENCODER_TYPE codecType`
- `HResolution` → `uint hResolution`
- `VResolution` → `uint vResolution`
- `AverageEncodeFps` → `uint averageEncodeFps`
- `AverageEncodeLatency` → `uint averageEncodeLatency`

**Note:** `GetEncoderSessionsInfo()` must be changed to build the sessions array from `info.pSessionInfo` pointer before the native struct goes out of scope. Change its signature to return null (not an empty DTO) when not supported.

---

### GROUP C — Illumination structs with complex union sub-DTOs

---

#### [x] 9. NVAPIGpuIllumDeviceInfoParamsDto (line ~3274)
**Native struct:** `_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_PARAMS_V1`
**Top-level fields:**
- `NumIllumDevices` → `uint numIllumDevices`
- `Devices` → `NVAPIGpuIllumDeviceInfoDto[]` (array of 32, indexed 0–31)

**Sub-DTO needed: `NVAPIGpuIllumDeviceInfoDto`** wrapping `_NV_GPU_CLIENT_ILLUM_DEVICE_INFO_V1`
**Fields from native:**
- `Type` → `NV_GPU_CLIENT_ILLUM_DEVICE_TYPE type`
- `CtrlModeMask` → `uint ctrlModeMask`
- `RawData` → `byte[]` (64 bytes from `data` union's rsvd variant — preserving union bytes since it's discriminated by `Type` and has 3 variants)

**Note on union:** `data` is a union of `mcuv10`, `gpioPwmRgbwv10`, `gpioPwmSingleColorv10`, and `rsvd[64]`. Since the active member is determined by `Type`, store the 64-byte union block as `RawData`. This is the only case where RawData at sub-DTO level is acceptable, because the outer DTO (the params struct) no longer has RawData.ok strart

---

#### [x] 10. NVAPIGpuIllumDeviceControlParamsDto (line ~3312)
**Native struct:** `NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_PARAMS_V1`
**Top-level fields:**
- `NumIllumDevices` → `uint numIllumDevices`
- `Devices` → `NVAPIGpuIllumDeviceControlDto[]` (array of 32)

**Sub-DTO needed: `NVAPIGpuIllumDeviceControlDto`** wrapping `NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1`.
Read `NV_GPU_CLIENT_ILLUM_DEVICE_CONTROL_V1.cs` before coding to get exact fields.

---

#### [x] 11. NVAPIGpuIllumZoneInfoParamsDto (line ~3350)
**Native struct:** `_NV_GPU_CLIENT_ILLUM_ZONE_INFO_PARAMS_V1`
**Top-level fields:**
- `NumIllumZones` → `uint numIllumZones`
- `Zones` → `NVAPIGpuIllumZoneInfoDto[]` (array of 32)

**Sub-DTO needed: `NVAPIGpuIllumZoneInfoDto`** wrapping `_NV_GPU_CLIENT_ILLUM_ZONE_INFO_V1`
**Fields from native:**
- `Type` → `NV_GPU_CLIENT_ILLUM_ZONE_TYPE type`
- `IllumDeviceIdx` → `byte illumDeviceIdx`
- `ProvIdx` → `byte provIdx`
- `ZoneLocation` → `NV_GPU_CLIENT_ILLUM_ZONE_LOCATION zoneLocation`
- `RawData` → `byte[]` (64 bytes from `data` union — same rationale as device info, union is type-discriminated)

---

#### [x] 12. NVAPIGpuIllumZoneControlParamsDto (line ~3388)
**Native struct:** `_NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_PARAMS_V1`
**Top-level fields:**
- `BDefault` → `bool bDefault` (bitfield)
- `NumIllumZonesControl` → `uint numIllumZonesControl`
- `Zones` → `NVAPIGpuIllumZoneControlDto[]` (array of 32)

**Sub-DTO needed: `NVAPIGpuIllumZoneControlDto`** wrapping `NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_V1`.
Read `NV_GPU_CLIENT_ILLUM_ZONE_CONTROL_V1.cs` before coding to get exact fields.

---

## EXECUTION ORDER
Do tasks in this order to minimise risk and keep build green:
1. Tasks 1–5 (Group A, flat structs) — simplest, validate the DTO refactor pattern
2. Tasks 7–8 (Group B minus pstates) — medium complexity
3. Tasks 9–12 (Group C, illumination) — array+sub-DTO pattern
4. Task 6 (Pstates) — most complex, do last
5. Task 13 (Facade test fixup) — after ALL DTOs done

Build after every completed DTO. Full test run after Task 13.

---

#### [x] 13. Facade test fixup — NVAPIPhysicalGpuHelperFacadeTests.cs
**File:** `NVAPIWrapper.FacadeTests/NVAPIPhysicalGpuHelperFacadeTests.cs`

After all DTOs are refactored, audit every test that touches one of the 12 changed DTOs and update assertions to use the new explicit properties instead of `RawData`.

**Checklist per affected test:**
- [ ] Tests for `GetVirtualizationInfo()` — assert on `VirtualizationMode` property
- [ ] Tests for `GetEncoderStatistics()` — assert on `SessionsCount`, `AverageFps`, `AverageLatency`
- [ ] Tests for `GetVrReadyData()` — assert on `IsVRReady` bool
- [ ] Tests for `GetGspFeatures()` — assert on `FirmwareVersion` string
- [ ] Tests for `GetNvlinkCaps()` — assert on `CapsTbl`, version fields, `LinkMask`
- [ ] Tests for `GetPstates20Info()` — assert on `IsEditable`, `NumPstates`, `Pstates` array length
- [ ] Tests for `GetLicensableFeatures()` — assert on `IsLicenseSupported`, `LicensableFeatureCount`, `LicenseDetails` array
- [ ] Tests for `GetEncoderSessionsInfo()` — assert on `SessionsCount`, `Sessions` array
- [ ] Tests for `GetIlluminationDevicesInfo()` — assert on `NumIllumDevices`, `Devices` array length and `Devices[i].Type`
- [ ] Tests for `GetIlluminationDevicesControl()` — assert on `NumIllumDevices`, `Devices` array
- [ ] Tests for `GetIlluminationZonesInfo()` — assert on `NumIllumZones`, `Zones` array length and `Zones[i].Type`
- [ ] Tests for `GetIlluminationZonesControl()` — assert on `BDefault`, `NumIllumZonesControl`, `Zones` array

**Rules for test updates:**
- Do NOT remove any test, only update assertions.
- If a test previously checked `dto.RawData != null && dto.RawData.Length > 0`, replace with a meaningful property check (e.g. count field > 0, or enum value is valid).
- Keep all existing `Skip.If` / hardware-gating logic unchanged.
- If a test cannot be updated meaningfully (because the feature has no good scalar to assert on), assert that the object is not null and that the struct-level count field is within expected range.
- After all tests compile, run: `dotnet test NVAPIWrapper.FacadeTests/NVAPIWrapper.FacadeTests.csproj --verbosity normal`
- Fix any test failures caused by the DTO changes (do NOT skip them to hide failures).

---

## OLD BUILD PLAN (ARCHIVED)
*(Original multi-phase build plan archived below for reference. Do not execute — project is already built.)*



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
1) Implement `NVAPIApiHelper` as the only entry point.
   - Do not expose direct accessors for helpers if multiple instances are possible.
   - Provide enumeration methods that return helper instances when multiple items exist.
2) Build helper classes per feature group (no "Services" in names):
   - `NVAPIPhysicalGpuHelper` and `NVAPILogicalGpuHelper` (logical GPUs included).
   - `NVAPIDisplayHelper` (enumerated via GPU helpers).
   - Maintain existing naming/pattern consistency.
3) Helper methods should map closely to native NVAPI function names:
   - e.g., `EnumeratePhysicalGpus`, `EnumerateLogicalGpus`, `EnumerateNvidiaDisplayHandles`.
   - Use the closest native-equivalent name for each helper function.
4) Implement DTOs for data structures:
   - Convert native structs to managed DTOs.
   - Ensure proper struct size/version setup.
   - Helpers remain stateful wrappers; getters return DTOs for snapshot/equality/persistence, setters accept DTOs to apply settings.
5) Implement strict lifetime and memory ownership rules:
   - Each helper owns any unmanaged memory it allocates.
   - Guard against use-after-dispose (throw `ObjectDisposedException`).
   - Avoid memory leaks and double-free scenarios.
6) Detailed implementation sequence for Phase 5:
   - Create `NVAPIApiHelper`:
     - Wrap `NVAPIApi` and expose `EnumeratePhysicalGpus()` and `EnumerateLogicalGpus()` returning helper instances.
     - Enforce disposal checks on every public method.
   - Create `NVAPIPhysicalGpuHelper`:
     - Store `NvPhysicalGpuHandle` internally (no raw pointer exposure).
     - Add read-only GPU methods aligned to native calls:
       - `GetFullName()` -> `NvAPI_GPU_GetFullName`
       - `GetBusId()` -> `NvAPI_GPU_GetBusId`
       - `GetBusType()` -> `NvAPI_GPU_GetBusType`
       - `GetGpuType()` -> `NvAPI_GPU_GetGPUType`
     - Add display enumeration:
       - `EnumerateNvidiaDisplayHandles()` returning `NVAPIDisplayHelper[]`.
       - Filter via `NvAPI_EnumNvidiaDisplayHandle` + `NvAPI_GetPhysicalGPUsFromDisplay`.
   - Create `NVAPILogicalGpuHelper`:
     - Store `NvLogicalGpuHandle` internally.
     - Add `GetPhysicalGpus()` -> `NvAPI_GetPhysicalGPUsFromLogicalGPU`.
   - Create `NVAPIDisplayHelper`:
     - Store `NvDisplayHandle` internally.
     - Add initial read-only display methods aligned to native calls (pick minimal safe set).
   - Add facade tests (hardware-aware):
     - `NVAPIPhysicalGpuHelperFacadeTests.cs`
     - `NVAPILogicalGpuHelperFacadeTests.cs`
     - `NVAPIDisplayHelperFacadeTests.cs`

### Facade DTO Pattern
- Helpers are stateful wrappers around NVAPI handles and lifetime checks.
- Getter methods return DTO snapshots for persistence/equality control.
- Setter methods accept DTOs and apply settings via native calls.
- DTOs are the boundary for equality and storage; helpers manage interop and memory.

Deliverable:
- `NVAPIApiHelper` and feature helpers with DTOs, enumerations, and safe lifetime handling.

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
- Phase 3 is complete (NVAPINative loader, NVAPIApi initialization/unload, NVAPIException, function availability map, and enumeration helpers).
- Phase 4 is complete (BasicApiTests in `NVAPIWrapper.NativeTests` passing with hardware-aware skips).
- AGENTS.md updated to align with NVAPI concepts and paths.
- Phase 5 is complete (facade helper design and implementation complete).
- Phase 6 is complete (facade tests added and hardware-aware gating applied).

## Next Action
Begin Phase 7 by implementing samples and updating documentation:
- Add sample apps in `Samples/` that exercise core enumeration and info queries.
- Update `README.md` to reflect the current API surface and usage patterns.

## In-Progress Work (2026-02) - Display Helper DISP Expansion
Objective: Add missing DISP display APIs to the facade (helpers + DTOs) with native and facade tests, including Active tests for setters.

Steps:
1) Unattached display support:
   - Add `NVAPIUnAttachedDisplayHelper` with functions that operate on unattached displays.
   - Add enumeration + lookup helpers in `NVAPIApi` and `NVAPIApiHelper`.
2) Display helper API expansion:
   - Add missing DISP functions to `NVAPIDisplayHelper`.
   - Create full DTOs for all new structures (HDR, color, infoframe, display id info, target info, custom display, managed dedicated display).
3) Native tests (first):
   - Add `NVAPIDisplayNativeTests` covering each new native API with hardware-aware skips.
4) Facade tests:
   - Passive tests for getters in `NVAPIDisplayHelperFacadeTests`.
   - Active tests for setters (safe set-to-current + revert) in `NVAPIDisplayHelperActiveTests`, following IGCL active test strategy.
   - Facade tests for unattached display helpers.

Status:
- Not started (pending implementation of steps 1-4).

## Pending API Decisions (Discuss Later)
- Display handle APIs to surface in facade (need guidance on placement and helper design):
  - `NvAPI_EnumNvidiaDisplayHandle`
  - `NvAPI_EnumNvidiaUnAttachedDisplayHandle`
  - `NvAPI_GetAssociatedNvidiaDisplayHandle`
  - `NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle`
- Non-paired or workflow-dependent display APIs needing guidance:
  - `NvAPI_CreateDisplayFromUnAttachedDisplay`
  - `NvAPI_GetUnAttachedAssociatedDisplayName`
  - `NvAPI_EnableHWCursor` / `NvAPI_DisableHWCursor`
  - `NvAPI_SetRefreshRateOverride`
  - `NvAPI_Disp_InfoFrameControl`
  - `NvAPI_Stereo_SetConfigurationProfileValue`
  - `NvAPI_DISP_AcquireDedicatedDisplay` / `NvAPI_DISP_ReleaseDedicatedDisplay`
  - `NvAPI_DISP_EnumCustomDisplay`
  - `NvAPI_DISP_TryCustomDisplay`
  - `NvAPI_DISP_DeleteCustomDisplay`
  - `NvAPI_DISP_SaveCustomDisplay`
  - `NvAPI_DISP_RevertCustomDisplayTrial`
