FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY dotnet-hello-world.sln global.json ./
COPY hello-world-api/hello-world-api.csproj hello-world-api/
COPY hello-world-api.Tests/hello-world-api.Tests.csproj hello-world-api.Tests/
RUN dotnet restore dotnet-hello-world.sln

COPY . .
RUN dotnet publish hello-world-api/hello-world-api.csproj \
    --configuration Release \
    --no-restore \
    --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "hello-world-api.dll"]
