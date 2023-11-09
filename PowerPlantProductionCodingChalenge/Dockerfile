FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore 
RUN dotnet publish "./PowerPlantProduction.API/PowerPlantProduction.API.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal 
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8888

ENTRYPOINT ["dotnet", "PowerPlantProduction.API.dll"]