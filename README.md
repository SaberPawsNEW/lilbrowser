# Lilbrowser

A small Windows Forms web browser made for fun. It uses the built-in `WebBrowser` control, with a responsive navigation bar, address validation, search fallback, and basic browser controls.

## What it does

- Opens `http` and `https` addresses (a missing scheme is treated as `https`).
- Sends normal text such as `cute otters` to Google Search.
- Rejects non-web schemes such as `file:`, `ftp:`, and `javascript:` rather than passing them to the embedded browser.
- Keeps the address bar, title, status line, and Back/Forward state in sync with the top-level page.
- Blocks pop-up windows instead of silently creating extra browser windows.

# btw this was vibecoded

## Build

Open `Lilbrowser.sln` in Visual Studio with the .NET Framework 4.6.2 developer pack installed, then build the solution. The app is Windows-only because Windows Forms and the built-in browser control are Windows technologies.

From a command prompt with MSBuild available:

```text
msbuild Lilbrowser.sln /p:Configuration=Release
```

## Tests

The solution includes a small dependency-free executable test project for address parsing and validation:

```text
Lilbrowser.Tests\bin\Release\Lilbrowser.Tests.exe
```

It runs without network access and covers URL normalization, local development addresses, search queries, blank input, and blocked schemes.

# This is now automated!
dependabot updates the dependincies, then it sees a pull request, and makes a realease
il make an installer ver every once and a while, still you should use the latest realease, even if it doesnt have an installer ver.
