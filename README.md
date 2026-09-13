# Lilbrowser

Lilbrowser is a compact Windows Forms browser shell targeting .NET Framework 4.6.2. It keeps the native `WebBrowser` control and layers a practical browser UI around it: navigation controls, a search-or-address bar, visible navigation progress, and an in-session downloads panel.

## Features

- Back, forward, refresh, and home controls
- Address input that accepts HTTP(S) URLs or searches Google for ordinary text
- Unsafe schemes such as `file:`, `ftp:`, and `javascript:` are rejected
- Progress indicator and status text while a page navigates
- Ctrl+L focuses the address bar
- Pop-ups are blocked
- Downloads use the browser control's native save dialog and are recorded in the visible session download history
- Downloads panel can open the system Downloads folder or clear its in-session history

## Build and test

Open `Lilbrowser.sln` in Visual Studio with the .NET Framework 4.6.2 targeting pack installed, then build the solution.

The solution contains a dependency-free console test project. From a developer command prompt, a typical validation sequence is:

```powershell
msbuild Lilbrowser.sln /t:Clean,Build /p:Configuration=Release
.\Lilbrowser.Tests\bin\Release\Lilbrowser.Tests.exe
```

The app uses the Windows Forms `WebBrowser` control, so its rendering engine and native download prompt are provided by Windows. The download panel is intentionally an in-session activity history rather than a separate download engine.
# Oh, and its automated by dependabot
every once and a while il add an installer ver tho
