# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/", "API/"]
COPY ["Application/", "Application/"]
COPY ["Domain/", "Domain"]
COPY ["Utilities/", "Utilities"]
COPY ["Infrastructure/", "Infrastructure"]

RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "API.csproj" -c $BUILD_CONFIGURATION -o /app/publish --property:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

#docker build -f "Dockerfile" -t jms:1.0 "../"
#docker run -p 8080:80 -e ASPNETCORE_ENVIRONMENT=Development jms:1.0
#http://localhost:5000/swagger/index.html
#docker compose down
#docker compose up --build
