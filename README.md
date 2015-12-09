![](http://misoftware.rs/Content/BlogCDN/csharp-bindings.png)

ACTUAL SCITER VERSION: 3.3.1.0

Windows NuGet: [![NuGet](https://img.shields.io/badge/nuget-v1.0.2-blue.svg)](https://www.nuget.org/packages/SciterSharpWindows/)

MONO/GTK NuGet: [![NuGet](https://img.shields.io/badge/nuget-v1.0.2-blue.svg)](https://www.nuget.org/packages/SciterSharpGTK/)


## Cross-platform Sciter bindings for .NET

This library provides bindings of Sciter C/C++ headers to the C# language. [Sciter](http://sciter.com/download/) is a multi-platform HTML engine. With this library you can create C#.NET desktop application using not just HTML, but all the features of Sciter: CSS3, SVG, scripintg, AJAX,... Sciter is free for commercial use.

The source is made portable to work in Windows and Linux/GTK+3/Mono.

License: GNU GENERAL PUBLIC LICENSE Version 3


## Quick Start

### Sciter Bootstrap

Quick start your desktop app by downloading a [Sciter Bootstrap package](http://misoftware.rs/Bootstrap/Download) for C#. The package contains a solution with 2 projects, one which you build for Windows with VS, and the other for MONO/GTK+3 with MonoDevelop. All projects comes with this library already configured and with Sciter native DLL already in the bin/ folder.

### NuGet

SciterSharp is available on NuGet.

There is a Windows package:
```
PM> Install-Package SciterSharpWindows
```

And a MONO/GTK+3 package: 

```
PM> Install-Package SciterSharpGTK
```

### From Source

Clone the repository and compile the project for your platform: SciterSharpWindows or SciterSharpGTK. In your project, add the resulting SciterSharpWindows.dll or SciterSharpGTK.dll as a reference.

## Requirements

Sciter native DLL must be added manually to your project, so go and grab a copy from [Sciter SDK](http://sciter.com/sdk/sciter-sdk-3.zip), I don't distribute it in any form.

So, for running you desktop app, you need to **make sure that your program can find sciter32/64.dll/.so**. The best way is to put a copy of each DLL in the *bin/Debug/* and *bin/Release/* folders.

### Windows
- requires at least .NET 4.5

In Visual Studio, make sure to **enable native debugging** so you will see Sciter error messages in the Output window: ```Project Properties / Debug / Check 'Enable native code debugging'```
 
### Mono/GTK+3
 
The Sciter native library requires the following packages:
- GTK+3: ```sudo apt-get install libgtk-3-0```
- libcurl: probably already installed in your distro


## Know Issues

Sciter have problems with video cards of old computers because the engine by default, is GPU accelerated. For me, in an old notebook I have, the execution hangs when I create the Sciter window. The solution is to switch the graphic engine to non-GPU mode, that is, CPU only. It's possible through the following Sciter API call:

```
SciterX.API.SciterSetOption(wnd._hwnd, SciterXDef.SCITER_RT_OPTIONS.SCITER_SET_GFX_LAYER,
new IntPtr(SciterXDef.GFX_LAYER.GFX_LAYER_WARP));
--or--
new IntPtr(SciterXDef.GFX_LAYER.GFX_LAYER_GDI));
```

## Classes API

The API is a complete OO wrap over Sciter C API making things more intuitive and organized.
There are 2 namespaces:

```SciterSharp``` - Public main instatiable classes.

```SciterSharp.Interop``` - Internal static classes, PInvoke definitions, Sciter ABI.

Here is a summary of the classes from SciterSharp namespace and their mapping over the official SDK C/C++ headers:

- **class SciterWindow**: API for creating a native window by PInvoke/SciterCreateWindow(), loading of HTML page via PInvoke/SciterLoadPage(), and message processing via callback for PInvoke/SciterCreateWindow()
- **abstract class SciterHost**: handling of host notifications generated by Sciter via PInvoke/SciterSetCallback(); attaching of event-handlers; registration of behaviors handlers (behavior factory); call function/eval script; and much more host related things
- **class SciterArchive**: open an archive from a binary array via PInvoke/SciterOpenArchive() and reading of file via PInvoke/SciterGetArchiveItem()
- **class SciterValue**: API over Sciter VALUE for manipulating/interfacing with TIScript (JSON data)
- **class SciterElement**: API over Sciter DOM manipulation (HELEMENT and HNODE) - status: **INCOMPLETE**
- **abstract class SciterEventHandler**: Sciter event-handler native callback; extend this class for handling Sciter events
- **abstract class SciterDebugOutputHandler**: API for handling Sciter debug messages; note that by default Sciter output messages to stdout only if SW_ENABLE_DEBUG is set when SciterCreateWindow() is called, so this class usage might be required if you need custom handling/suppress of the output


## Todo's (help appreciated) 

- HELEMENT / SciterElement API
- Windows Forms control
- WPF control
- add as C# documentation all the helpful API comments found in the official Sciter SDK C headers