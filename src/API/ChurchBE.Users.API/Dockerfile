# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
#EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/API/ChurchBE.Users.API/ChurchBE.Users.API.csproj", "src/API/ChurchBE.Users.API/"]
COPY ["src/Common/ChurchBE.Common.Infrastructure/ChurchBE.Common.Infrastructure.csproj", "src/Common/ChurchBE.Common.Infrastructure/"]
COPY ["src/Common/ChurchBE.Common.Application/ChurchBE.Common.Application.csproj", "src/Common/ChurchBE.Common.Application/"]
COPY ["src/Common/ChurchBE.Common.Domain/ChurchBE.Common.Domain.csproj", "src/Common/ChurchBE.Common.Domain/"]
COPY ["src/Common/ChurchBE.Common.Presentation/ChurchBE.Common.Presentation.csproj", "src/Common/ChurchBE.Common.Presentation/"]
COPY ["src/Modules/Users/ChurchBE.Modules.Users.Infrastructure/ChurchBE.Modules.Users.Infrastructure.csproj", "src/Modules/Users/ChurchBE.Modules.Users.Infrastructure/"]
COPY ["src/Modules/Users/ChurchBE.Modules.Users.Application/ChurchBE.Modules.Users.Application.csproj", "src/Modules/Users/ChurchBE.Modules.Users.Application/"]
COPY ["src/Modules/Users/ChurchBE.Modules.Users.Domain/ChurchBE.Modules.Users.Domain.csproj", "src/Modules/Users/ChurchBE.Modules.Users.Domain/"]
COPY ["src/Modules/Users/ChurchBE.Modules.Users.IntegrationEvents/ChurchBE.Modules.Users.IntegrationEvents.csproj", "src/Modules/Users/ChurchBE.Modules.Users.IntegrationEvents/"]
COPY ["src/Modules/Users/ChurchBE.Modules.Users.Presentation/ChurchBE.Modules.Users.Presentation.csproj", "src/Modules/Users/ChurchBE.Modules.Users.Presentation/"]
RUN dotnet restore "./src/API/ChurchBE.Users.API/ChurchBE.Users.API.csproj"
COPY . .
WORKDIR "/src/src/API/ChurchBE.Users.API"
RUN dotnet build "./ChurchBE.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChurchBE.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChurchBE.Users.API.dll"]