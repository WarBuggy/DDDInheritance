param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"

$dbMigratorFolder = Join-Path $slnFolder "src/DDDInheritance.DbMigrator"

Write-Host "********* BUILDING DbMigrator *********" -ForegroundColor Green
Set-Location $dbMigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/dddinheritance-db-migrator:$version .




$webFolder = Join-Path $slnFolder "src/DDDInheritance.Web"

Write-Host "********* BUILDING Web Application *********" -ForegroundColor Green
Set-Location $webFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/dddinheritance-web:$version .

$hostFolder = Join-Path $slnFolder "src/DDDInheritance.HttpApi.Host"
$identityServerAppFolder = Join-Path $slnFolder "src/DDDInheritance.IdentityServer"

Write-Host "********* BUILDING Api.Host Application *********" -ForegroundColor Green
Set-Location $hostFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/dddinheritance-api:$version .

$authServerAppFolder = Join-Path $slnFolder "src/DDDInheritance.AuthServer"
Set-Location $authServerAppFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/dddinheritance-authserver:$version .


### ALL COMPLETED
Write-Host "COMPLETED" -ForegroundColor Green
Set-Location $currentFolder