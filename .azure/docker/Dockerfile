# First stage: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# Copy the solution file and project files
COPY PowerPlantProduction.sln ./
COPY src/ ./src/
COPY tests/ ./tests/

# Restore dependencies and publish the application
RUN dotnet restore
RUN dotnet publish -c Release -o out ./src/Web/Web.csproj

# Second stage: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /source/out .

# Expose port 80 for the application
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Web.dll"]
