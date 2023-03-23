#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MusalaSoftDrones.Api/MusalaSoftDrones.Api.csproj", "MusalaSoftDrones.Api/"]
RUN dotnet restore "MusalaSoftDrones.Api/MusalaSoftDrones.Api.csproj"
COPY . .
WORKDIR "/src/MusalaSoftDrones.Api"
RUN dotnet build "MusalaSoftDrones.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusalaSoftDrones.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusalaSoftDrones.Api.dll"]