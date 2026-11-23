# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: `net10.0`
- **Upgrade Scope**: Entire solution
- **Commit Strategy**: Single Commit at End (recommended for the All-at-Once strategy)

## Source Control
- **Source Branch**: `main`
- **Working Branch**: `upgrade-dotnet-10`
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Auto (Merge)

## Upgrade Options

### Strategy
- Upgrade Strategy: All-at-Once

### Compatibility
- Unsupported Packages: Resolve Inline (2 incompatible packages)

## Strategy
**Selected**: All-at-Once

### Execution Constraints
- Upgrade all three projects together; do not sequence by dependency tier.
- Verify the .NET 10 SDK and any `global.json` SDK pin before project changes.
- Update target frameworks and package references, then resolve the UI behavioral-change finding.
- Restore, build the full solution, and run tests after the atomic upgrade.
