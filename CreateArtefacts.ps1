$artefactDir = "Artefacts"
$tempDir = "Temp"
$configuration = "Debug"
$version = "0.6.1"
$rootPath = "."

function Main {
    if (Test-Path $artefactDir) {
        rd $artefactDir -Recurse
    }
    md -Name $artefactDir

    if (Test-Path $tempDir) {
        rd $tempDir -Recurse
    }
    md -Name $tempDir

    # FlaUInspect
    $inspectDir = Join-Path $tempDir "FlaUInspect-$version"
    Copy-Item -Path $rootPath\src\FlaUInspect\bin\$configuration -Destination $inspectDir -Recurse
    Get-ChildItem $inspectDir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $inspectDir

    # FlaUI.Core
    $coreDir = Join-Path $tempDir "FlaUI.Core"
    $coren45Dir = Join-Path $coreDir net45
    $coren40Dir = Join-Path $coreDir net40
    $coren35Dir = Join-Path $coreDir net35
    md -Name $coreDir
    md -Name $coren45Dir
    md -Name $coren40Dir
    md -Name $coren35Dir
    Get-ChildItem $rootPath\src\FlaUI.Core\bin\$configuration | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $coren45Dir
    Get-ChildItem $rootPath\src\FlaUI.Core\bin\$configuration\net-4.0 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $coren40Dir
    Get-ChildItem $rootPath\src\FlaUI.Core\bin\$configuration\net-3.5 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $coren35Dir
    Get-ChildItem $coreDir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $coreDir

    # FlaUI.UIA2
    $uia2Dir = Join-Path $tempDir "FlaUI.UIA2"
    $uia2n45Dir = Join-Path $uia2Dir net45
    $uia2n40Dir = Join-Path $uia2Dir net40
    $uia2n35Dir = Join-Path $uia2Dir net35
    md -Name $uia2Dir
    md -Name $uia2n45Dir
    md -Name $uia2n40Dir
    md -Name $uia2n35Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA2\bin\$configuration | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia2n45Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA2\bin\$configuration\net-4.0 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia2n40Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA2\bin\$configuration\net-3.5 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia2n35Dir
    Get-ChildItem $ui23Dir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $uia2Dir

    # FlaUI.UIA3
    $uia3Dir = Join-Path $tempDir "FlaUI.UIA3"
    $uia3n45Dir = Join-Path $uia3Dir net45
    $uia3n40Dir = Join-Path $uia3Dir net40
    $uia3n35Dir = Join-Path $uia3Dir net35
    md -Name $uia3Dir
    md -Name $uia3n45Dir
    md -Name $uia3n40Dir
    md -Name $uia3n35Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA3\bin\$configuration | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia3n45Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA3\bin\$configuration\net-4.0 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia3n40Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA3\bin\$configuration\net-3.5 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia3n35Dir
    Get-ChildItem $uia3Dir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $uia3Dir

    # Create Zips
    [Reflection.Assembly]::LoadWithPartialName("System.IO.Compression.FileSystem")
    $compression = [System.IO.Compression.CompressionLevel]::Optimal
    $includeBaseDirectory = $false
    [System.IO.Compression.ZipFile]::CreateFromDirectory($inspectDir, (Join-Path $artefactDir "FlaUInspect-$version.zip"), $compression, $includeBaseDirectory)
    [System.IO.Compression.ZipFile]::CreateFromDirectory($coreDir, (Join-Path $artefactDir "FlaUI.Core-$version.zip"), $compression, $includeBaseDirectory)
    [System.IO.Compression.ZipFile]::CreateFromDirectory($uia2Dir, (Join-Path $artefactDir "FlaUI.UIA2-$version.zip"), $compression, $includeBaseDirectory)
    [System.IO.Compression.ZipFile]::CreateFromDirectory($uia3Dir, (Join-Path $artefactDir "FlaUI.UIA3-$version.zip"), $compression, $includeBaseDirectory)

    Create-Packages

    # Cleanup
    rd $tempDir -Recurse
}

function Deploy-License($dest) {
    Copy-Item -Path $rootPath\CHANGELOG.md -Destination $dest
    Copy-Item -Path $rootPath\LICENSE.txt -Destination $dest
}

function Create-Packages() {
    nuget pack "$rootPath\src\FlaUI.Core\FlaUI.Core.csproj" -Properties "Configuration=$configuration;Platform=AnyCPU" -IncludeReferencedProjects -OutputDirectory $artefactDir
    nuget pack "$rootPath\src\FlaUI.UIA2\FlaUI.UIA2.csproj" -Properties "Configuration=$configuration;Platform=AnyCPU" -IncludeReferencedProjects -OutputDirectory $artefactDir
    nuget pack "$rootPath\src\FlaUI.UIA3\FlaUI.UIA3.csproj" -Properties "Configuration=$configuration;Platform=AnyCPU" -IncludeReferencedProjects -OutputDirectory $artefactDir
    choco pack "$rootPath\src\FlaUInspect\FlaUInspect.nuspec" -OutputDirectory $artefactDir
}

Main