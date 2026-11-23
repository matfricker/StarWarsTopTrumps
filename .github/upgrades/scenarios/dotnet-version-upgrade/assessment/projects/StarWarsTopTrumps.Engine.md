# StarWarsTopTrumps.Engine\StarWarsTopTrumps.Engine.csproj

[← Back to the assessment index](../../assessment.md)

## Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 0
- **Dependants**: 2
- **Number of Files**: 6
- **Number of Files with Incidents**: 1
- **Lines of Code**: 225
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

## Related Projects

**Depended on by (2)** — projects that reference this one:

- [D:\StarWarsTopTrumps\StarWarsTopTrumps.Tests\StarWarsTopTrumps.Tests.csproj](../projects/StarWarsTopTrumps.Tests.md)
- [D:\StarWarsTopTrumps\StarWarsTopTrumps.UI\StarWarsTopTrumps.UI.csproj](../projects/StarWarsTopTrumps.UI.md)

## Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (2)"]
        P2["<b>📦&nbsp;StarWarsTopTrumps.UI.csproj</b><br/><small>net8.0</small>"]
        P3["<b>📦&nbsp;StarWarsTopTrumps.Tests.csproj</b><br/><small>net8.0</small>"]
        click P2 "../projects/StarWarsTopTrumps.UI.md"
        click P3 "../projects/StarWarsTopTrumps.Tests.md"
    end
    subgraph current["StarWarsTopTrumps.Engine.csproj"]
        MAIN["<b>📦&nbsp;StarWarsTopTrumps.Engine.csproj</b><br/><small>net8.0</small>"]
        click MAIN "../projects/StarWarsTopTrumps.Engine.md"
    end
    P2 --> MAIN
    P3 --> MAIN

```

## API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 211 |  |
| ***Total APIs Analyzed*** | ***211*** |  |

