## Galdur

Galdur is a WIP framework for building multi-platform desktop applications using C#. It's powered by [webview](https://github.com/webview/webview) and compatible with any frontend web framework you want to use.

Features:
* Cross-platform (Windows, Linux, macOS)
* Call C# methods asynchronously from frontend javascript/typescript
* Hot-reload
* Native file system integration
* Single file executable
* Reasonable binary size (example is 23.7MB)

![screenshot](screenshot.png)

## Debugging

To debug the application open a terminal and start the server. Make sure you're in the GaldurTest project directory.

```
npm install
npm run dev
```

Then just hit `F5` and you can start and debug the application like normal.

## Building

The frontend is served from the files embedded into the assembly on build, so the first step is to build the frontend.

```
npm install
npm run build
```

Then you can build the app as a single file using `dotnet publish`. Just be sure to update to the platform of your choice.

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=True -p:TrimMode=link
```
