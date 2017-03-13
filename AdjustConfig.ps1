$newVersion = "1.0.0"
$suffix = "-beta2"
$newConfiguration = "Release"

function Main() {
	ReplaceVersion
	ReplaceConfiguration
}

function ReplaceVersion {
	RegexReplaceTextInFile "CreateArtefacts.ps1" "(?<=\`$version = `").*?(?=`")" "$($newVersion)$($suffix)"
    RegexReplaceTextInFile "src\FlaUInspect\FlaUInspect.nuspec" "(?<=<version>).*?(?=</version>)" "$($newVersion)$($suffix)"

    ReplaceAssemblyVersion "src\FlaUI.Core\Properties\AssemblyInfo.cs"
    ReplaceAssemblyVersion "src\FlaUI.UIA2\Properties\AssemblyInfo.cs"
    ReplaceAssemblyVersion "src\FlaUI.UIA3\Properties\AssemblyInfo.cs"
    ReplaceAssemblyVersion "src\FlaUInspect\Properties\AssemblyInfo.cs"
}

function ReplaceConfiguration {
	RegexReplaceTextInFile "CreateArtefacts.ps1" "(?<=\`$configuration = `").*?(?=`")" $newConfiguration
	RegexReplaceTextInFile "src\FlaUInspect\FlaUInspect.nuspec" "(?<=src=`"bin\\).*?(?=\\)" $newConfiguration
}

function ReplaceAssemblyVersion($assemblyFile) {
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyVersion\(`").*?(?=`"\))" $newVersion
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyFileVersion\(`").*?(?=`"\))" $newVersion
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyInformationalVersion\(`").*?(?=`"\))" "$($newVersion)$($suffix)"
}

function RegexReplaceTextInFile($file, $from, $to) {
    $content = [System.IO.File]::ReadAllText($file)
    $content = $content -replace $from, $to
    [System.IO.File]::WriteAllText($file, $content)
}

Main
