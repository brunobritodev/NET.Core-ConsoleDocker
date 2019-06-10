FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DockerConsole/DockerConsole.csproj", "DockerConsole/"]
RUN dotnet restore "DockerConsole/DockerConsole.csproj"
COPY . .
WORKDIR "/src/DockerConsole"
RUN dotnet build "DockerConsole.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerConsole.csproj" -c Release -o /app

FROM base AS final
# Configure timezone
RUN unlink /etc/localtime
RUN ln -s /usr/share/zoneinfo/Brazil/East /etc/localtime

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerConsole.dll"]