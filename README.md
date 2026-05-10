# GetCodeGenie Migrator

A one-shot migration utility for [GetCodeGenie](https://github.com/alan-ingham/getcodegenie).

Converts GetCodeGenie snapshot files (`.gcg2p`) from the legacy BinaryFormatter binary format to JSON, in preparation for the GetCodeGenie migration to .NET 10.

## Background

GetCodeGenie stores project snapshots — highlights, underlines, indices, colours, and document rich text — in `.gcg2p` files serialised with `BinaryFormatter`. BinaryFormatter was removed in .NET 9, so existing snapshot files must be converted to JSON before the main app can be upgraded.

## Usage

1. Run **GetCodeGenie Migrator**
2. Click **Choose Directory** and select a folder containing `.gcg2p` files
3. Click **Convert**

Each `.gcg2p` file is converted to a `.gcg2p.json` file alongside it. Files that already have a JSON counterpart are skipped, so the tool is safe to re-run. Any file that fails to convert is reported individually without aborting the rest.

## Requirements

- Windows
- .NET Framework 4.8

## Building

Open `GetCodeGenieMigrator/GetCodeGenieMigrator.sln` in Visual Studio. Restore NuGet packages (Newtonsoft.Json 13.0.3), then build.

The Inno Setup installer script is at `Installer/GetCodeGenieMigrator.iss`.

---

© Alan Ingham 2026
