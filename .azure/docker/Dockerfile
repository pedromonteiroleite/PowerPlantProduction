# First stage: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# Copy the solution file and project files
COPY PowerPlantProduction.sln ./
COPY src/Web/Web.csproj ./src/Web/
COPY src/Application/Application.csproj ./src/Application/
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY src/Domain/Domain.csproj ./src/Domain/
COPY tests/Domain.Tests/Domain.Tests.csproj ./tests/Domain.Tests/

# Restore dependencies
RUN dotnet restore

# Copy the remaining source code and publish the application
COPY src/Web/ ./src/Web/
COPY src/Application/ ./src/Application/
COPY src/Infrastructure/ ./src/Infrastructure/
COPY src/Domain/ ./src/Domain/
COPY tests/Domain.Tests/ ./tests/Domain.Tests/
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
