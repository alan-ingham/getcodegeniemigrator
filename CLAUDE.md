# Claude context — GetCodeGenie Migrator

## Purpose

One-shot migration utility for GetCodeGenie. Converts `.gcg2p` snapshot files from
BinaryFormatter binary format to JSON. Prerequisite for migrating GetCodeGenie to .NET 10.

## Location

`D:\Users\Alan\Documents\Programming\C#\GetCodeGenieMigrator\`
GitHub: https://github.com/alan-ingham/getcodegeniemigrator

## Project structure

```
GetCodeGenieMigrator/           ← git repo root
  GetCodeGenieMigrator/         ← VS solution folder
    GetCodeGenieMigrator.ico
    GetCodeGenieMigrator.sln
    GetCodeGenieMigrator/       ← VS project folder (.NET 4.8 WinForms)
      GcgTypes.cs               ← [Serializable] copies of GetCodeGenie data classes
                                   (same GetCodeGenie namespace + field names — required
                                   for BinaryFormatter to map correctly)
      GcgDtos.cs                ← Clean DTO classes for JSON output (no BinaryFormatter)
      GcgSerializationBinder.cs ← Redirects BinaryFormatter type lookups from assembly
                                   "GetCodeGenie" to this assembly; also rewrites
                                   assembly refs embedded inside generic type args
      Migrator.cs               ← Load binary → map to DTOs → write JSON
      GetCodeGenieMigrator.cs   ← Main form
  Installer/
    GetCodeGenieMigrator.iss    ← Inno Setup script
```

## Key technical notes

- **GcgTypes.cs must stay in namespace `GetCodeGenie`** — BinaryFormatter bakes both
  the type name and assembly name into the file. The binder handles the assembly redirect;
  the namespace must match literally.
- **Field names in GcgTypes.cs must not be renamed** — BinaryFormatter uses field names
  (not property names) as serialisation keys. `m_nStart`, `m_nColourRectangle`, etc. must
  be preserved exactly.
- **Generic types** need special binder handling — `List<StateOneDocument>` embeds the
  assembly reference inside the generic argument brackets. The binder uses a regex to
  rewrite all occurrences, not just the outer type.
- **Colours are stored as ARGB ints** in the JSON output (`Color.ToArgb()`). The .NET 10
  main app should use `Color.FromArgb(int)` to restore them.
- **JSON format** (StateDto/StateOneDocumentDto/etc. in GcgDtos.cs) is the format the
  .NET 10 GetCodeGenie will read. Don't change it without updating both sides.

## Dependencies

- Newtonsoft.Json 13.0.3 (NuGet, packages.config style)

## Coding style

Matches GetCodeGenie conventions: C#, WinForms, .NET 4.8, old-style csproj.
