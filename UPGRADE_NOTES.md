# Upgrade notes

The original project targeted unsupported `netcoreapp2.0` and referenced `Microsoft.AspNetCore.All` 2.0.0. This version:

- targets `net10.0`;
- uses the current ASP.NET Core hosting model and Minimal APIs;
- removes `Startup.cs`, legacy MVC setup, and obsolete package references;
- keeps the original `/api/hello` endpoint;
- adds `/health` and a root redirect;
- includes a real xUnit test project;
- includes an Azure Pipeline that restores, builds, tests, publishes, creates a ZIP, and uploads it;
- includes Docker and Cloud Foundry deployment files;
- fixes the nested repository layout that caused repeated `dotnet-hello-world-master` paths.
