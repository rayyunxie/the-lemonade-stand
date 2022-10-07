#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tls.api/tls.api.csproj", "tls.api/"]
RUN dotnet restore "tls.api/tls.api.csproj"
COPY . .
WORKDIR "/src/tls.api"
RUN dotnet build "tls.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tls.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tls.api.dll"]