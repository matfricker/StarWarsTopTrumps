# 01-prerequisites: Verify .NET 10 SDK prerequisites

Verify the installed .NET SDK and any repository SDK pin support the requested `net10.0` target before changing project files. Identify whether a `global.json` pin needs to be updated so restores and builds use a compatible SDK.

## Research Findings
- Scope: all three SDK-style projects (`StarWarsTopTrumps.Engine`, `StarWarsTopTrumps.Tests`, and `StarWarsTopTrumps.UI`) in the solution; no project changes are needed for this prerequisite check.
- `validate_dotnet_sdk_installation` reports a compatible .NET 10 SDK. A repository search found no `global.json`, so there is no SDK pin to update.
- Build-tool guidance: the projects are SDK-style and target modern .NET; use `dotnet build` for validation.

**Done when**: The .NET 10 SDK is available for the solution, and any `global.json` SDK pin is compatible with it.
