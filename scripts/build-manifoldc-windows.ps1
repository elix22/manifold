# Build script for manifoldc library on Windows
# Usage: .\build-manifoldc-windows.ps1 [-Architecture <arch>] [-BuildType <type>]
# Example: .\build-manifoldc-windows.ps1 -Architecture x64 -BuildType Release
# Example: .\build-manifoldc-windows.ps1 -Architecture Win32 -BuildType Debug
# Architectures: x64, Win32, ARM64

param(
    [string]$Architecture = "x64",
    [string]$BuildType = "Release"
)

$ErrorActionPreference = "Stop"

$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$ManifoldDir = Split-Path -Parent $ScriptDir
$BuildDir = Join-Path $ManifoldDir "build-windows-$Architecture"

Write-Host "==========================================" -ForegroundColor Cyan
Write-Host "Building manifoldc for Windows" -ForegroundColor Cyan
Write-Host "Architecture: $Architecture" -ForegroundColor Cyan
Write-Host "Build Type: $BuildType" -ForegroundColor Cyan
Write-Host "==========================================" -ForegroundColor Cyan

# Create build directory
New-Item -ItemType Directory -Force -Path $BuildDir | Out-Null
Set-Location $BuildDir

# Configure with CMake
Write-Host "Configuring CMake..." -ForegroundColor Yellow
cmake $ManifoldDir `
    -G "Visual Studio 17 2022" `
    -A $Architecture `
    -DCMAKE_BUILD_TYPE="$BuildType" `
    -DMANIFOLD_CBIND=ON `
    -DMANIFOLD_CROSS_SECTION=ON `
    -DMANIFOLD_PYBIND=OFF `
    -DMANIFOLD_JSBIND=OFF `
    -DMANIFOLD_TEST=OFF `
    -DMANIFOLD_PAR=OFF `
    -DBUILD_SHARED_LIBS=ON

if ($LASTEXITCODE -ne 0) {
    Write-Host "✗ CMake configuration failed" -ForegroundColor Red
    exit 1
}

# Build only manifoldc target
Write-Host "Building manifoldc..." -ForegroundColor Yellow
cmake --build . --config $BuildType --target manifoldc

if ($LASTEXITCODE -ne 0) {
    Write-Host "✗ Build failed" -ForegroundColor Red
    exit 1
}

Write-Host "==========================================" -ForegroundColor Cyan
Write-Host "Build complete!" -ForegroundColor Green
Write-Host "==========================================" -ForegroundColor Cyan

# Verify the library was created
$DllPath = Get-ChildItem -Path $BuildDir -Recurse -Filter "manifoldc.dll" | Select-Object -First 1
if ($null -ne $DllPath) {
    Write-Host "✓ Successfully built manifoldc.dll" -ForegroundColor Green
    Get-Item $DllPath.FullName | Format-Table Name, Length, LastWriteTime

    # Copy to the expected location
    if ($BuildType -eq "Debug") {
        $OutputDir = Join-Path $ManifoldDir "libs\windows\$Architecture\debug"
    } else {
        $OutputDir = Join-Path $ManifoldDir "libs\windows\$Architecture\release"
    }

    New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null
    Copy-Item $DllPath.FullName $OutputDir -Force
    Write-Host "✓ Copied to $OutputDir\manifoldc.dll" -ForegroundColor Green
} else {
    Write-Host "✗ Failed to build manifoldc.dll" -ForegroundColor Red
    exit 1
}
