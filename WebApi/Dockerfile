# Runtime base
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5002
EXPOSE 5002

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Copy project files first (preserve relative paths for ProjectReferences)
COPY ["WebApi/WebAPI.csproj", "WebApi/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Data/Data.csproj", "Data/"]

# Restore only the Web API project (avoids restoring UnitTest inside container)
RUN dotnet restore "WebApi/WebAPI.csproj"

# Copy the rest of the source
COPY . .

# Build
WORKDIR /src/WebApi
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
WORKDIR /src/WebApi
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WebAPI.dll"]