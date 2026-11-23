# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

Detailed findings live alongside this file in `assessment/`. This page is the index: read it first, then open only the documents you need.

## Table of Contents

- [Executive Summary](#executive-summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Detailed Reports](#detailed-reports)
  - [Projects Relationship Graph](assessment/project-graph.md)
  - [Aggregate NuGet packages details](assessment/nuget/aggregate-packages.md)
  - [Most Frequent API Issues (complete list)](assessment/api-issues/most-frequent-api-issues.md)
  - [Project Details](#project-details)

## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 3 | All require upgrade |
| Total NuGet Packages | 55 | 3 need upgrade |
| Total Code Files | 16 |  |
| Total Code Files with Incidents | 4 |  |
| Total Lines of Code | 626 |  |
| Total Number of Issues | 7 |  |
| Proposed Target Framework | net10.0 |  |
| Estimated LOC to modify | 1+ | at least 0.2% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Binding Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :---: | :--- |
| [StarWarsTopTrumps.Engine\StarWarsTopTrumps.Engine.csproj](assessment/projects/StarWarsTopTrumps.Engine.md) | net8.0 | 🟢 Low | 0 | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [StarWarsTopTrumps.Tests\StarWarsTopTrumps.Tests.csproj](assessment/projects/StarWarsTopTrumps.Tests.md) | net8.0 | 🟢 Low | 0 | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [StarWarsTopTrumps.UI\StarWarsTopTrumps.UI.csproj](assessment/projects/StarWarsTopTrumps.UI.md) | net8.0 | 🟢 Low | 3 | 1 | 0 | 1+ | AspNetCore, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 52 | 94.5% |
| ⚠️ Incompatible | 2 | 3.6% |
| 🔄 Upgrade Recommended | 1 | 1.8% |
| ***Total NuGet Packages*** | ***55*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 1 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 1683 |  |
| ***Total APIs Analyzed*** | ***1684*** |  |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |
| M:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder,System.String) | 1 | 100.0% | Behavioral Change |

The table above is the top 10. See [the complete list](assessment/api-issues/most-frequent-api-issues.md) for every affected API.

## Detailed Reports

- [Projects Relationship Graph](assessment/project-graph.md)
- [Aggregate NuGet packages details](assessment/nuget/aggregate-packages.md)
- [Most Frequent API Issues (complete list)](assessment/api-issues/most-frequent-api-issues.md)

### Project Details

- [StarWarsTopTrumps.Engine\StarWarsTopTrumps.Engine.csproj](assessment/projects/StarWarsTopTrumps.Engine.md)
- [StarWarsTopTrumps.Tests\StarWarsTopTrumps.Tests.csproj](assessment/projects/StarWarsTopTrumps.Tests.md)
- [StarWarsTopTrumps.UI\StarWarsTopTrumps.UI.csproj](assessment/projects/StarWarsTopTrumps.UI.md)


