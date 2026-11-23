# .NET Version Upgrade Plan

## Overview

**Target**: Upgrade all projects in `StarWarsTopTrumps.sln` from .NET 8 to .NET 10.
**Scope**: 3 SDK-style projects and approximately 626 lines of code.

### Selected Strategy
**All-at-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: 3 low-difficulty SDK-style projects target `net8.0`, and the assessment shows a small dependency graph.

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | All-at-Once | The assessment finds 3 SDK-style projects on `net8.0`, all rated low difficulty, with a small dependency graph. |
| Unsupported Packages | Resolve Inline | The assessment flags 2 incompatible packages, a limited scope for researching and resolving during the upgrade. |

## Tasks

### 01-prerequisites: Verify .NET 10 SDK prerequisites

Verify the installed .NET SDK and any repository SDK pin support the requested `net10.0` target before changing project files. Identify whether a `global.json` pin needs to be updated so restores and builds use a compatible SDK.

**Done when**: The .NET 10 SDK is available for the solution, and any `global.json` SDK pin is compatible with it.

### 02-upgrade-all-projects: Upgrade the solution to .NET 10

Retarget `StarWarsTopTrumps.Engine`, `StarWarsTopTrumps.Tests`, and `StarWarsTopTrumps.UI` from `net8.0` to `net10.0` together. Resolve the two packages the assessment marks incompatible inline, update the UI project's `Newtonsoft.Json` recommendation from 13.0.3 to 13.0.4, and investigate the `UseExceptionHandler(IApplicationBuilder, string)` behavioral-change finding so exception handling remains intentional. The assessment reports no binary- or source-incompatible APIs; use its project and package reports as research starting points rather than duplicating package detail here.

**Done when**: All three projects target `net10.0`; incompatible package findings are resolved for .NET 10; the recommended Newtonsoft.Json update is applied; and the exception-handler behavior is preserved or deliberately updated.

### 03-final-validation: Validate the upgraded solution

Run restore and a full solution build, then execute the test project. Address build warnings and failures in the upgraded projects and verify there are no dependency conflicts or unresolved .NET 10 incompatibilities. Record any follow-up recommendation that cannot be safely resolved within the upgrade.

**Done when**: The full solution builds without errors or warnings, tests pass, and remaining package or API compatibility issues are documented.
