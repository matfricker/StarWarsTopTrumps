# Progress Details — 02-upgrade-all-projects

- Retargeted `StarWarsTopTrumps.Engine`, `StarWarsTopTrumps.Tests`, and `StarWarsTopTrumps.UI` to `net10.0`.
- Updated UI package references to `Azure.Identity` 1.21.0, `Microsoft.Azure.SignalR` 1.34.0, and `Newtonsoft.Json` 13.0.4. The first two versions address the assessment's deprecated dependency/security findings; the NuGet vulnerability audit reports no vulnerable packages in any project.
- Kept `Startup.Configure`'s `UseExceptionHandler("/Error")` unchanged. The reported .NET 10 diagnostic behavior applies when a custom `IExceptionHandler.TryHandleAsync` handles an exception; none is registered or implemented in this app.
- Validation: full solution build succeeded; all 3 tests passed; `dotnet list package --vulnerable --include-transitive` found no vulnerable packages.
- Files changed: the three project files. No API compatibility source edits were needed.
