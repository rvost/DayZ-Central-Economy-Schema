Param(
    [Parameter()][string]$FolderPath,
    [Parameter()][string]$OutputFolderPath = $PSScriptRoot
)

if (-not (Test-Path -Path $FolderPath -PathType Container)) {
    Write-Host "The specified folder does not exist." -ForegroundColor Red
    exit
}

if (-not (Test-Path -Path $OutputFolderPath -PathType Container)) {
   Write-Host "The specified output folder does not exist. Using the current folder." -ForegroundColor Red
    $OutputFolderPath = $PSScriptRoot
}


$XmlFilePaths = Get-ChildItem -Path $FolderPath -Filter "*.xml" -Recurse | Where-Object { !$_.PSIsContainer }

$xsdExe = 'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe'

foreach ($xmlFile in $XmlFilePaths) {
    & $xsdExe $xmlFile.FullName "/out:${OutputFolderPath}"
}
