FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:5002
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src
COPY . .
WORKDIR /src/WebApi
RUN dotnet restore WebAPI.csproj
RUN dotnet publish WebAPI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]