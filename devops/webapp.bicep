param webAppName string
param connectionString string
param location string = 'westeurope' 

resource appServicePlan 'Microsoft.Web/serverfarms@2023-01-01' = {
  name: '${webAppName}Plan'
  location: location
  sku: {
    name: 'F1'
    tier: 'Free'
  }
}

resource webApp 'Microsoft.Web/sites@2020-12-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      netFrameworkVersion: 'v6.0'
      scmType: 'None'
      appSettings: [
        {
          name: 'ConnectionStrings:HospitalDb'
          value: connectionString
        }
      ]
    }
  }
}
