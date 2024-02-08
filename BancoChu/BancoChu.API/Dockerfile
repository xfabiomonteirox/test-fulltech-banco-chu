FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BancoChu.API/BancoChu.API.csproj", "BancoChu.API/"]
COPY ["BancoChu.Application/BancoChu.API.csproj", "BancoChu.Application/"]
COPY ["BancoChu.Domain/BancoChu.API.csproj", "BancoChu.Domain/"]
COPY ["BancoChu.Infrastructure/BancoChu.API.csproj", "BancoChu.Infrastructure/"]
COPY ["BancoChu.Persistence/BancoChu.API.csproj", "BancoChu.Persistence/"]

RUN dotnet restore "./BancoChu.API/./BancoChu.API.csproj"
COPY . .
WORKDIR "/src/BancoChu.API"
RUN dotnet build "./BancoChu.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BancoChu.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BancoChu.API.dll"]