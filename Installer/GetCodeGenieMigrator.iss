; GetCodeGenie Migrator — Inno Setup Script

#define AppName "GetCodeGenie Migrator"
#define AppVersion "1.0"
#define AppPublisher "Alan Ingham"
#define AppExeName "GetCodeGenieMigrator.exe"

[Setup]
AppId={{15D39D74-C6FD-47C4-93CC-9FB5F7CF9084}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
OutputDir=Output
OutputBaseFilename=GetCodeGenieMigratorSetup
SetupIconFile=..\GetCodeGenieMigrator\GetCodeGenieMigrator.ico
UninstallDisplayIcon={app}\{#AppExeName}
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "..\GetCodeGenieMigrator\GetCodeGenieMigrator\bin\Release\{#AppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\GetCodeGenieMigrator\GetCodeGenieMigrator\bin\Release\GetCodeGenieMigrator.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\GetCodeGenieMigrator\GetCodeGenieMigrator\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
