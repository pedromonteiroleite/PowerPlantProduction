## Create azure container registry resource

      # Create container registry
      az acr create -n acrpowerplant -g rgPowerPlantProduction --sku Standard

      # Enable admin required to set/retrieve credentials
      az acr update -n acrpowerplant --admin-enabled true # Enable admin first

      # Retrieve ACR credentials and store them in a variable
      $acrCredentials = az acr credential show --name acrpowerplant --resource-group rgPowerPlantProduction | ConvertFrom-Json

      # Extract username and password from the output
      $acrUsername = $acrCredentials.username
      $acrPassword = $acrCredentials.passwords[0].value

      # Use the retrieved credentials
      Write-Output "ACR Username: $acrUsername"
      Write-Output "ACR Password: $acrPassword"

## Dockerfile

      # First stage: Build the application
      FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
      WORKDIR /source

      # Copy the .csproj files and restore dependencies
      COPY .azure/docker/*.csproj ./
      RUN dotnet restore

      # Copy the remaining source code and publish the application
      COPY src/Web/ ./
      RUN dotnet publish -c Release -o out

      # Second stage: Create the runtime image
      FROM mcr.microsoft.com/dotnet/aspnet:6.0
      WORKDIR /app

      # Copy the published output from the build stage
      COPY --from=build /source/out .

      # Expose port 80 for the application
      EXPOSE 80

      # Set the entry point for the application
      ENTRYPOINT ["dotnet", "Web.dll"]

## Create image

      docker build -f .azure/docker/Dockerfile -t powerplant_web_api .

## Push image to registry

      # Login to acr
      az acr login

      # Build and tag image
      docker build

      # Push the image
      docker push
