FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AreaLibConsole/AreaLibConsole.csproj", "AreaLibConsole/"]
RUN dotnet restore "AreaLibConsole/AreaLibConsole.csproj"
COPY . .
WORKDIR "/src/AreaLibConsole"
RUN dotnet build "AreaLibConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AreaLibConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AreaLibConsole.dll"]
