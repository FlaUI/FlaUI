$artefactDir = "Artefacts"
$tempDir = "Temp"
$version = "1.0.0-beta3"
$rootPath = "."

function Main {
    if (Test-Path $artefactDir) {
        rd $artefactDir -Recurse | Out-Null
    }
    md -Name $artefactDir | Out-Null

    if (Test-Path $tempDir) {
        rd $tempDir -Recurse | Out-Null
    }
    md -Name $tempDir | Out-Null

    # FlaUInspect
    $inspectDir = Join-Path $tempDir "FlaUInspect-$version"
    Copy-Item -Path $rootPath\src\FlaUInspect\bin -Destination $inspectDir -Recurse
    Get-ChildItem $inspectDir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $inspectDir

    # FlaUI.Core
    $coreDir = Join-Path $tempDir "FlaUI.Core"
    $coren45Dir = Join-Path $coreDir net45
    $coren40Dir = Join-Path $coreDir net40
    $coren35Dir = Join-Path $coreDir net35
    md -Name $coreDir | Out-Null
    md -Name $coren45Dir | Out-Null
    md -Name $coren40Dir | Out-Null
    md -Name $coren35Dir | Out-Null
    Get-ChildItem $rootPath\src\FlaUI.Core\bin | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $coren45Dir
    Get-ChildItem $rootPath\src\FlaUI.Core\bin\net-4.0 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $coren40Dir
    Get-ChildItem $rootPath\src\FlaUI.Core\bin\net-3.5 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $coren35Dir
    Get-ChildItem $coreDir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $coreDir

    # FlaUI.UIA2
    $uia2Dir = Join-Path $tempDir "FlaUI.UIA2"
    $uia2n45Dir = Join-Path $uia2Dir net45
    $uia2n40Dir = Join-Path $uia2Dir net40
    $uia2n35Dir = Join-Path $uia2Dir net35
    md -Name $uia2Dir | Out-Null
    md -Name $uia2n45Dir | Out-Null
    md -Name $uia2n40Dir | Out-Null
    md -Name $uia2n35Dir | Out-Null
    Get-ChildItem $rootPath\src\FlaUI.UIA2\bin | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia2n45Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA2\bin\net-4.0 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia2n40Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA2\bin\net-3.5 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia2n35Dir
    Get-ChildItem $uia2Dir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $uia2Dir

    # FlaUI.UIA3
    $uia3Dir = Join-Path $tempDir "FlaUI.UIA3"
    $uia3n45Dir = Join-Path $uia3Dir net45
    $uia3n40Dir = Join-Path $uia3Dir net40
    $uia3n35Dir = Join-Path $uia3Dir net35
    md -Name $uia3Dir | Out-Null
    md -Name $uia3n45Dir | Out-Null
    md -Name $uia3n40Dir | Out-Null
    md -Name $uia3n35Dir | Out-Null
    Get-ChildItem $rootPath\src\FlaUI.UIA3\bin | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia3n45Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA3\bin\net-4.0 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia3n40Dir
    Get-ChildItem $rootPath\src\FlaUI.UIA3\bin\net-3.5 | Where-Object { !$_.PSIsContainer } | Copy-Item -Destination $uia3n35Dir
    Get-ChildItem $uia3Dir -Include *.pdb,*.xml,*.vshost.*,*RANDOM_SEED* -Recurse | Remove-Item
    Deploy-License $uia3Dir

    # Create Zips
    [Reflection.Assembly]::LoadWithPartialName("System.IO.Compression.FileSystem") | Out-Null
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
    nuget pack "$rootPath\nuspec\FlaUI.Core.nuspec" -OutputDirectory $artefactDir -properties version=$version
    nuget pack "$rootPath\nuspec\FlaUI.UIA2.nuspec" -OutputDirectory $artefactDir -properties version=$version
    nuget pack "$rootPath\nuspec\FlaUI.UIA3.nuspec" -OutputDirectory $artefactDir -properties version=$version
    choco pack "$rootPath\nuspec\FlaUInspect.nuspec" -OutputDirectory $artefactDir --version $version
}

Main