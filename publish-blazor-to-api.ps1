# PowerShell script to publish Blazor and copy to API wwwroot

$blazorProject = "FamilyTrip.Frontend"
$apiWwwroot = "FamilyTrip.API\wwwroot"

# Publish Blazor WASM
Write-Host "Publishing Blazor WebAssembly project..."
dotnet publish $blazorProject -c Release -o publish-blazor

# Remove old wwwroot (optional, be careful!)
if (Test-Path $apiWwwroot) {
    Remove-Item $apiWwwroot -Recurse -Force
}

# Copy new Blazor build to API wwwroot
Write-Host "Copying Blazor build output to API wwwroot..."
Copy-Item "publish-blazor\wwwroot" $apiWwwroot -Recurse

# Clean up
Remove-Item "publish-blazor" -Recurse -Force

Write-Host "Blazor published and copied to API wwwroot."
