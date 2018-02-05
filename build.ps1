Param(
  [int]$buildDefinitionId
)

$tfsUrl = $env:SYSTEM_TEAMFOUNDATIONCOLLECTIONURI;

$projectName = $env:SYSTEM_TEAMPROJECT;

$url = "$tfsUrl$projectName/_apis/build/builds?definitions=$buildDefinitionId&api-version=2.0"

Write-Host $url

$definition = Invoke-RestMethod -Uri $url -Headers @{
    Authorization = "Bearer $env:SYSTEM_ACCESSTOKEN"
}

$result = $definition.value | % { $_.startTime }

Write-Host $result