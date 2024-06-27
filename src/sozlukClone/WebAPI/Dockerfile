#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/sozlukClone/WebAPI/WebAPI.csproj", "src/sozlukClone/WebAPI/"]
COPY ["src/sozlukClone/Application/Application.csproj", "src/sozlukClone/Application/"]
COPY ["src/sozlukClone/Domain/Domain.csproj", "src/sozlukClone/Domain/"]
COPY ["src/sozlukClone/Infrastructure/Infrastructure.csproj", "src/sozlukClone/Infrastructure/"]
COPY ["src/sozlukClone/Persistence/Persistence.csproj", "src/sozlukClone/Persistence/"]
RUN dotnet restore "./src/sozlukClone/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/src/sozlukClone/WebAPI"
RUN dotnet build "./WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]