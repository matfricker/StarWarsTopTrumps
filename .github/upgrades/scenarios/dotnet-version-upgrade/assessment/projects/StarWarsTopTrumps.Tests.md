# StarWarsTopTrumps.Tests\StarWarsTopTrumps.Tests.csproj

[← Back to the assessment index](../../assessment.md)

## Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 4
- **Number of Files with Incidents**: 1
- **Lines of Code**: 71
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

## Related Projects

**Depends on (1)** — projects this one references:

- [D:\StarWarsTopTrumps\StarWarsTopTrumps.Engine\StarWarsTopTrumps.Engine.csproj](../projects/StarWarsTopTrumps.Engine.md)

## Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["StarWarsTopTrumps.Tests.csproj"]
        MAIN["<b>📦&nbsp;StarWarsTopTrumps.Tests.csproj</b><br/><small>net8.0</small>"]
        click MAIN "../projects/StarWarsTopTrumps.Tests.md"
    end
    subgraph downstream["Dependencies (1)"]
        P1["<b>📦&nbsp;StarWarsTopTrumps.Engine.csproj</b><br/><small>net8.0</small>"]
        click P1 "../projects/StarWarsTopTrumps.Engine.md"
    end
    MAIN --> P1

```

## API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 90 |  |
| ***Total APIs Analyzed*** | ***90*** |  |

