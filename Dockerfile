FROM microsoft/dotnet:2.2-sdk-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebApiScaffold.Core/*.csproj ./WebApiScaffold.Core/
COPY WebApiScaffold.Infrastructure/*.csproj ./WebApiScaffold.Infrastructure/
COPY WebApiScaffold.WebApi/*.csproj ./WebApiScaffold.WebApi/
RUN dotnet restore

# copy everything else and build app
COPY WebApiScaffold.Core/. ./WebApiScaffold.Core/
COPY WebApiScaffold.Infrastructure/. ./WebApiScaffold.Infrastructure/
COPY WebApiScaffold.WebApi/. ./WebApiScaffold.WebApi/
WORKDIR /app
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=build /app/WebApiScaffold.WebApi/out ./
ENTRYPOINT ["dotnet", "WebApiScaffold.WebApi.dll"]