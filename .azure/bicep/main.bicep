param projectName string
param location string
@allowed([
  'nonprod'
  'prod'
])
param environmentType string = 'nonprod'
@description('A unique suffix to add to resource names that need to be globally unique.')
@maxLength(13)
param resourceNameSuffix string = uniqueString(resourceGroup().id)
param sqlAdministratorUsername string = ''
@secure()
param sqlAdministratorPassword string = ''
@secure()
param myIpAddress string = ''

module storageAccount 'modules/StorageAccount.bicep' = {
  name: 'storageAccount'
  params: {
    location: location
    projectName: projectName
    environmentType: environmentType
  }
}

module appService 'modules/appService.bicep' = {
  name: 'appService'
  params: {
    location: location
    projectName: projectName
    environmentType: environmentType
  }
}

module sqlServer 'modules/sqlServer.bicep' = {
  name: 'sqlServer'
  params: {
    location: location
    projectName: projectName
    environmentType: environmentType
    resourceNameSuffix: resourceNameSuffix
    sqlAdministratorUsername: sqlAdministratorUsername
    sqlAdministratorPassword: sqlAdministratorPassword
    myIpAddress: myIpAddress
  }
}

output appServiceAppHostName string = appService.outputs.appServiceAppHostName
