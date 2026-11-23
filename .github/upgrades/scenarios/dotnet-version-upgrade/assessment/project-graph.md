# Projects Relationship Graph

[← Back to the assessment index](../assessment.md)

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;StarWarsTopTrumps.Engine.csproj</b><br/><small>net8.0</small>"]
    P2["<b>📦&nbsp;StarWarsTopTrumps.UI.csproj</b><br/><small>net8.0</small>"]
    P3["<b>📦&nbsp;StarWarsTopTrumps.Tests.csproj</b><br/><small>net8.0</small>"]
    P2 --> P1
    P3 --> P1
    click P1 "projects/StarWarsTopTrumps.Engine.md"
    click P2 "projects/StarWarsTopTrumps.UI.md"
    click P3 "projects/StarWarsTopTrumps.Tests.md"

```

