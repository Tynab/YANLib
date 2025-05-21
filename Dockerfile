FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && \
    apt-get install -y \
    curl \
    unzip \
    python3 \
    python3-pip \
    && pip3 install awscli \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /yanlib
COPY ["lib/YANLib/YANLib.csproj", "lib/YANLib/"]
COPY ["host/YANLib.HttpApi.Host/YANLib.HttpApi.Host.csproj", "host/YANLib.HttpApi.Host/"]
COPY ["src/YANLib.Application/YANLib.Application.csproj", "src/YANLib.Application/"]
COPY ["src/YANLib.Application.Redis/YANLib.Application.Redis.csproj", "src/YANLib.Application.Redis/"]
COPY ["src/YANLib.Application.Contracts/YANLib.Application.Contracts.csproj", "src/YANLib.Application.Contracts/"]
COPY ["src/YANLib.Domain/YANLib.Domain.csproj", "src/YANLib.Domain/"]
COPY ["src/YANLib.Domain.Shared/YANLib.Domain.Shared.csproj", "src/YANLib.Domain.Shared/"]
COPY ["src/YANLib.EntityFrameworkCore/YANLib.EntityFrameworkCore.csproj", "src/YANLib.EntityFrameworkCore/"]
COPY ["src/YANLib.HttpApi/YANLib.HttpApi.csproj", "src/YANLib.HttpApi/"]
COPY ["src/YANLib.HttpApi.Client/YANLib.HttpApi.Client.csproj", "src/YANLib.HttpApi.Client/"]
COPY ["src/YANLib.MongoDB/YANLib.MongoDB.csproj", "src/YANLib.MongoDB/"]
RUN dotnet restore "host/YANLib.HttpApi.Host/YANLib.HttpApi.Host.csproj"
COPY . .
WORKDIR "/yanlib/host/YANLib.HttpApi.Host"
RUN dotnet build "YANLib.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YANLib.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY aws-configure.sh /app/aws-configure.sh
RUN chmod +x /app/aws-configure.sh

ENTRYPOINT ["/bin/bash", "-c", "/app/aws-configure.sh && dotnet YANLib.HttpApi.Host.dll"]