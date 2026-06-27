# MultiHtmlCraaft.AvaloniaControl_Tesst

## Overview
`MultiHtmlCraaft.AvaloniaControl_Tesst` is a test project using Avalonia UI that serves as a sample application for verifying and demonstrating the Avalonia control implementation of the `MultiHtmlCraft` core library. It is mainly intended for validating custom controls and UI integration during development.

## Features
- Desktop UI sample built on Avalonia
- Integration test project for `MultiHtmlCraft.AvaroniaControl` (core)
- Sample control: `Controls/MultiversalAvaroniaView.axaml` (visual host)

## About `MultiHtmlCraft.AvaroniaControl`
`MultiHtmlCraft.AvaroniaControl` is the Avalonia-specific UI library that integrates the `MultiHtmlCraft` core rendering/document model with Avalonia applications. Key features include:

- Avalonia control wrapper(s) that host `MultiHtmlCraft` document rendering
- APIs to load and update `CHtmlDocument` or other core document types
- Event surface to handle user interaction (clicks, focus, input) from Avalonia controls to the core library
- Styling and theming integration via Avalonia styles and templates
- Cross-platform support through Avalonia (Windows / macOS / Linux)
- Designed to be used from .NET 6 and .NET 9 projects (project targets may vary)

## Requirements
- .NET SDK (this workspace contains projects targeting `.NET 6` and `.NET 9`)
- Avalonia UI (refer to the project `csproj` for package references)
- .NET runtime on Windows / macOS / Linux

## Build and run
1. Change to the repository root (where the solution is located).
2. Build the solution and dependencies:

```
dotnet build
```

3. Run the test application (specify the project file):

```
dotnet run --project MultiHtmlCraaft.AvaloniaControl_Tesst/MultiHtmlCraaft.AvaloniaControl_Tesst.csproj
```

You can also open and run the project from Visual Studio, Rider, or VS Code.

## Usage (quick)
- Open `Controls/MultiversalAvaroniaView.axaml` and inspect the displayed UI.
- The control implementation code is located in the `MultiHtmlCraft.AvaroniaControl` project.
- Rebuild the solution after making changes and verify the behavior.

## Contributing
Bug reports and feature improvements are welcome. Please ensure your changes build successfully before submitting a pull request.

## License
See the `LICENSE` file at the repository root for the project license.
