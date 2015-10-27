# These variables should be set via the Octopus web portal:
#
#   ConnectionString         - The .Net connection string for the DB
Write-Host "Connection String: <"$ConnectionString">"

# Get the exe name based on the directory
#$contentPath  = (Join-Path $OctopusOriginalPackageDirectoryPath "content")
#$fullPath = (Join-Path $contentPath "migrate.exe")

$fullPath = (Join-Path $OctopusOriginalPackageDirectoryPath "migrate.exe")
Write-Host "Migrate Path:" $fullPath

#cd $contentPath
Write-Host "Working Dir: "$(get-location)

# Run the migration utility
& "$fullPath" Demo.XBanking.Data.dll /startUpConfigurationFile=Demo.XBanking.Data.dll.config /connectionString=$ConnectionString /connectionProviderName="System.Data.SqlClient" /verbose | Write-Host
#& ".\migrate.exe" Demo.XBanking.Data.dll /startUpConfigurationFile=Demo.XBanking.Data.dll.config /connectionString=$ConnectionString /connectionProviderName="System.Data.SqlClient" /verbose
