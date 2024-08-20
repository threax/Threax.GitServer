FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM threax/build-dotnet:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/Threax.GitServer
RUN --mount=type=cache,target=node_modules,id=threax-build-gitserver npm install
RUN --mount=type=cache,target=/root/.nuget/packages,id=threax-build-dotnet-nuget dotnet restore Threax.GitServer.csproj
RUN --mount=type=cache,target=/root/.nuget/packages,id=threax-build-dotnet-nuget dotnet build Threax.GitServer.csproj -c Release -o /app
RUN --mount=type=cache,target=node_modules,id=threax-build-gitserver npm run clean
RUN --mount=type=cache,target=node_modules,id=threax-build-gitserver npm run build

FROM build AS publish
RUN --mount=type=cache,target=/root/.nuget/packages,id=threax-build-dotnet-nuget dotnet publish Threax.GitServer.csproj -c Release -o /app

FROM base AS final
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Install git
RUN apt-get update &&\
    apt-get install git -y &&\
    apt-get autoremove &&\
    apt-get clean

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Threax.GitServer.dll"]
