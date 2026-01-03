# .NET Practice App
Simple Todo minimal API to practice TeamCity pipelines.

Commands:

- Build project:

```bash
dotnet build src/TodoApp/TodoApp.csproj
```

- Run tests:

```bash
dotnet test tests/TodoApp.Tests/TodoApp.Tests.csproj
```

TeamCity tip: create a build configuration that runs `powershell` with `build.ps1` on Windows agents, or use a command-line step invoking the `dotnet` CLI directly.
