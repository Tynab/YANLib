#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["lib/YANLib/nuget.config", "lib/YANLib/"]
COPY ["host/YANLib.HttpApi.Host/YANLib.HttpApi.Host.csproj", "host/YANLib.HttpApi.Host/"]
COPY ["src/YANLib.Application/YANLib.Application.csproj", "src/YANLib.Application/"]
COPY ["lib/YANLib/YANLib.csproj", "lib/YANLib/"]
COPY ["src/YANLib.Domain/YANLib.Domain.csproj", "src/YANLib.Domain/"]
COPY ["src/YANLib.Domain.Shared/YANLib.Domain.Shared.csproj", "src/YANLib.Domain.Shared/"]
COPY ["src/YANLib.Application.Contracts/YANLib.Application.Contracts.csproj", "src/YANLib.Application.Contracts/"]
COPY ["src/YANLib.EntityFrameworkCore/YANLib.EntityFrameworkCore.csproj", "src/YANLib.EntityFrameworkCore/"]
COPY ["src/YANLib.HttpApi/YANLib.HttpApi.csproj", "src/YANLib.HttpApi/"]
RUN dotnet restore "host/YANLib.HttpApi.Host/YANLib.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/host/YANLib.HttpApi.Host"
RUN dotnet build "YANLib.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YANLib.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YANLib.HttpApi.Host.dll"]