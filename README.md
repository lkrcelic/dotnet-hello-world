# Hello World ASP.NET Core API — .NET 10 LTS

This is a clean upgrade of the original .NET Core 2.0 sample to **.NET 10 LTS**.

## Repository layout

The ZIP is intentionally flat: extract it into the root of a new repository. Do not place it inside another copy of `dotnet-hello-world-master`.

```text
azure-pipelines.yml
dotnet-hello-world.sln
global.json
hello-world-api/
hello-world-api.Tests/
```

## Requirements

Install a .NET 10 SDK. `global.json` requests SDK 10.0.100 or a newer .NET 10 feature band.

## Commands in the recommended order

```bash
# 1. Download NuGet dependencies
dotnet restore dotnet-hello-world.sln

# 2. Compile the application and test project
dotnet build dotnet-hello-world.sln --configuration Release --no-restore

# 3. Run automated tests
dotnet test hello-world-api.Tests/hello-world-api.Tests.csproj \
  --configuration Release \
  --no-build \
  --no-restore

# 4. Create deployable files
dotnet publish hello-world-api/hello-world-api.csproj \
  --configuration Release \
  --no-build \
  --no-restore \
  --output publish
```

`dotnet build` compiles the projects but does **not** execute tests. `dotnet test` executes the included xUnit test.

## Run locally

```bash
dotnet run --project hello-world-api/hello-world-api.csproj
```

Open:

- `http://localhost:5000/api/hello`
- `http://localhost:5000/health`
- `http://localhost:5000/`

## Azure Pipelines

In Azure DevOps, create a pipeline from **Existing Azure Pipelines YAML file** and select `/azure-pipelines.yml`.

The pipeline runs:

```text
restore -> build -> test -> publish -> ZIP -> upload artifact
```

The uploaded artifact is named `drop` and contains `hello-world-api.zip`.

## Docker

```bash
docker build -t hello-world-api .
docker run --rm -p 8080:8080 hello-world-api
```

Then open `http://localhost:8080/api/hello`.

## Cloud Foundry

```bash
dotnet publish hello-world-api/hello-world-api.csproj \
  --configuration Release \
  --output publish
cf push
```
