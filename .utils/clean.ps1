# All bin/ and obj/ folders will be deleted

$folders = Get-ChildItem -Recurse -Directory -Include bin,obj

foreach ($folder in $folders) {
    Remove-Item $folder.FullName -Recurse
}