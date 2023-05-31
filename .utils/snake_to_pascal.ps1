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

$string = $args[0]
$newString = ConvertTo-PascalCase $string

# Print result:
Write-Host $newString