$fontFile = $args[0]

# Get only the file name without the extension
$fontFileName = (Get-Item $fontFile).BaseName

.\dist\msdf-atlas-gen.exe -font $fontFile -fontname $fontFileName -type msdf -format png -square4 -imageout mtsdf.png -json mtsdf.json -size 64 -pxrange 8 -scanline

# Package up the font files into a zip file
Compress-Archive -Path "mtsdf.png", "mtsdf.json" -DestinationPath "$fontFileName.zip"

# Rename .zip to .font
Rename-Item "$fontFileName.zip" "$fontFileName.font"

# Remove the font files
Remove-Item "mtsdf.png", "mtsdf.json"