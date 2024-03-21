## Create azure container registry (acr)

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

## .azure/docker/Dockerfile

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


## Create image

      # Sample using relative files located in folders other than the the context one
      docker build -f .azure/docker/Dockerfile -t powerplant_web_api .

## Push image to acr

      # Tag image (MUST be tagged with acr name, otherwise it wont allow push)
      docker tag powerplant_web_api_2 acrpowerplant.azurecr.io/powerplant_web_api_2

      # Login to acr
      az acr login --name acrpowerplant --username [] --password []

      # Push the image
      docker push acrpowerplant.azurecr.io/powerplant_web_api_2

## List acr images

      az acr repository list -n acrpowerplant
