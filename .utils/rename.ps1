$ErrorActionPreference = "Stop"

function ConvertTo-PascalCase {
    param (
        [Parameter(Mandatory = $true)]
        [string]$inputString
    )
    
    $words = $inputString -split '[_-]'
    $pascalWords = $words | ForEach-Object { 
        if ($_ -match '^[A-Za-z]') {
            $_.Substring(0, 1).ToUpper() + $_.Substring(1).ToLower()
        }
        else {
            $_
        }
    }
    $pascalString = [string]::Join('', $pascalWords)
    
    return $pascalString
}

$currentName = $args[0]
$newName = $args[1]
$newNamePascal = ConvertTo-PascalCase $newName

# Rename stuff inside of files
# ----------------------------
# Get current root namespace in .csproj file:
$csproj = "src/$currentName/$currentName.csproj"
$rootNamespace = Select-Xml -Path $csproj -XPath "//PropertyGroup/RootNamespace" | ForEach-Object { $_.node.InnerXML }

# Convert to PascalCase:
$newRootNamespace = $newNamePascal

# Replace root namespace in .csproj file:
(Get-Content "src/$currentName/$currentName.csproj") -replace $rootNamespace, $newRootNamespace | Set-Content "src/$currentName/$currentName.csproj"

# Replace names in .sln file:
(Get-Content "src/$currentName.sln") -replace $currentName, $newName | Set-Content "src/$currentName.sln"

# Replace occurences in all .cs files:
Get-ChildItem -Path "src" -Filter *.cs -Recurse | ForEach-Object {
    $newContent = (Get-Content $_.FullName) -replace $rootNamespace, $newRootNamespace
    Set-Content $_.FullName $newContent
}


# Files to rename:
$files = "src/$currentName.sln", "src/$currentName/$currentName.csproj"

# Rename files:
foreach ($file in $files) {
    $ext = [System.IO.Path]::GetExtension($file)
    Rename-Item -Force $file "$newName$ext"
}

# Directories to rename:
$dirs = "src/$currentName"

# Rename directories:
foreach ($dir in $dirs) {
    Rename-Item -Force $dir $newName
}