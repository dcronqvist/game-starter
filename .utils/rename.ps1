$ErrorActionPreference = "Stop"

function ConvertTo-PascalCase {
    param (
        [Parameter(Mandatory=$true)]
        [string]$inputString
    )
    
    $words = $inputString -split '[_-]'
    $pascalWords = $words | ForEach-Object { 
        if ($_ -match '^[A-Za-z]') {
            $_.Substring(0,1).ToUpper() + $_.Substring(1).ToLower()
        } else {
            $_
        }
    }
    $pascalString = [string]::Join('', $pascalWords)
    
    return $pascalString
}

$currentName = $args[0]
$newName = $args[1]

# Files to rename:
$files = "src/$currentName.sln", "src/$newName/$currentName.csproj"
# Directories to rename:
$dirs = "src/$currentName"

# Rename directories:
foreach ($dir in $dirs) {
    Rename-Item -Force $dir $newName
}

# Rename files:
foreach ($file in $files) {
    $ext = [System.IO.Path]::GetExtension($file)
    Rename-Item -Force $file "$newName$ext"
}

# Get current root namespace in .csproj file:
[xml]$csproj = Get-Content "src/$newName/$newName.csproj"
$rootNamespace = $csproj.Project.PropertyGroup.RootNamespace

# Convert to PascalCase:
$newRootNamespace = ConvertTo-PascalCase $newName

# Replace root namespace in .csproj file:
(Get-Content "src/$newName/$newName.csproj") -replace $rootNamespace, $newRootNamespace | Set-Content "src/$newName/$newName.csproj"

# Replace names in .sln file:
(Get-Content "src/$newName.sln") -replace $currentName, $newName | Set-Content "src/$newName.sln"

# Replace occurences in all .cs files:
Get-ChildItem -Path "src" -Filter *.cs -Recurse | ForEach-Object {
    $newContent = (Get-Content $_.FullName) -replace $rootNamespace, $newRootNamespace
    Set-Content $_.FullName $newContent
}