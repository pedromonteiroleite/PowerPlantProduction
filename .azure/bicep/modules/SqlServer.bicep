param location string
param projectName string
@allowed([
  'nonprod'
  'prod'
])
param environmentType string
@description('A unique suffix to add to resource names that need to be globally unique.')
@maxLength(13)
param resourceNameSuffix string = uniqueString(resourceGroup().id)

param sqlAdministratorUsername string
@secure()
param sqlAdministratorPassword string
@secure()
param myIpAddress string 

var sqlServerName = 'sql${projectName}-${resourceNameSuffix}'
var sqlDatabaseName = 'db${projectName}'
var environmentConfigurationMap = {
  prod: {
    sqlDatabase: {
      sku: {
        name: 'Standard'
        tier: 'Standard'
      }
    }
  }
  nonProd: {
    sqlDatabase: {
      sku: {
        name: 'Standard'
        tier: 'Standard'
      }
    }
  }
}
var sqlDatabaseSku = environmentConfigurationMap[environmentType].sqlDatabase.sku

resource sqlServer 'Microsoft.Sql/servers@2021-02-01-preview' = {
  name: sqlServerName
  location: location
  properties: {
    administratorLogin: sqlAdministratorUsername
    administratorLoginPassword: sqlAdministratorPassword
  }
}

resource sqlDatabase 'Microsoft.Sql/servers/databases@2021-02-01-preview' = {
  parent: sqlServer
  name: sqlDatabaseName
  location: location
  sku: sqlDatabaseSku
}

resource sqlServer_FirewallRule 'Microsoft.Sql/servers/firewallRules@2021-02-01-preview' = {
  parent: sqlServer
  name: 'AllowMyIpAddress'
  properties: {
    endIpAddress: myIpAddress
    startIpAddress: myIpAddress
  }
}

output sqlServerFullyQualifiedDomainName string = sqlServer.properties.fullyQualifiedDomainName
output sqlDatabaseName string = sqlDatabase.name
