# Dockerfile for EricControllerBasedApi
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env
WORKDIR /app

# Copy SharedLibrary project and restore as distinct layers
COPY ./SharedLibrary/*.csproj ./SharedLibrary/
RUN dotnet restore ./SharedLibrary/SharedLibrary.csproj

# Copy EricControllerBasedApi project and restore as distinct layers
COPY ./EricControllerBasedApi/*.csproj ./EricControllerBasedApi/
RUN dotnet restore ./EricControllerBasedApi/EricControllerBasedApi.csproj

# Copy everything else and build
COPY ./EricControllerBasedApi/ ./EricControllerBasedApi/
COPY ./SharedLibrary ./SharedLibrary
RUN dotnet publish ./EricControllerBasedApi/EricControllerBasedApi.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:5269
EXPOSE 5269
ENTRYPOINT ["dotnet", "EricControllerBasedApi.dll"]