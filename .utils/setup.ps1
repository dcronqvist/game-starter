$ErrorActionPreference = "Stop"

# Create random temporary directory
$TempDir = Join-Path $env:TEMP ([System.IO.Path]::GetRandomFileName())
New-Item -ItemType Directory -Path $TempDir | Out-Null

# If the libs directory already exists, remove it
if (Test-Path "libs/") {
    Remove-Item -Force -Path "libs/" -Recurse
}

# Create libs directory
New-Item -ItemType Directory -Path "libs/" | Out-Null
New-Item -ItemType Directory -Path "libs/win64/" | Out-Null

# Download GLFW binaries for windows
$GLFWZip = Join-Path $TempDir "winglfw.zip"
Invoke-WebRequest -Uri "https://github.com/glfw/glfw/releases/download/3.3.8/glfw-3.3.8.bin.WIN64.zip" -OutFile $GLFWZip

# Extract GLFW binaries
Expand-Archive -Path $GLFWZip -DestinationPath $TempDir

# Copy GLFW binaries to the correct location
Copy-Item -Path "$TempDir/glfw-3.3.8.bin.WIN64/lib-vc2022/glfw3.dll" -Destination "libs/win64/glfw3.dll"

# Remove temporary directory
Remove-Item -Path $TempDir -Recurse