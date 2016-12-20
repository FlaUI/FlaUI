$newVersion = "0.6.2"
$newConfiguration = "Release"

function Main() {
	ReplaceVersion
	ReplaceConfiguration
}

function ReplaceVersion {
	RegexReplaceTextInFile "CreateArtefacts.ps1" "(?<=\`$version = `").*?(?=`")" $newVersion
    RegexReplaceTextInFile "src\FlaUInspect\FlaUInspect.nuspec" "(?<=<version>).*?(?=</version>)" $newVersion

    ReplaceAssemblyVersion "src\FlaUI.Core\Properties\AssemblyInfo.cs" $newVersion
    ReplaceAssemblyVersion "src\FlaUI.UIA2\Properties\AssemblyInfo.cs" $newVersion
    ReplaceAssemblyVersion "src\FlaUI.UIA3\Properties\AssemblyInfo.cs" $newVersion
    ReplaceAssemblyVersion "src\FlaUInspect\Properties\AssemblyInfo.cs" $newVersion
}

function ReplaceConfiguration {
	RegexReplaceTextInFile "CreateArtefacts.ps1" "(?<=\`$configuration = `").*?(?=`")" $newConfiguration
	RegexReplaceTextInFile "src\FlaUInspect\FlaUInspect.nuspec" "(?<=src=`"bin\\).*?(?=\\)" $newConfiguration
}

function ReplaceAssemblyVersion($assemblyFile, $version) {
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyVersion\(`").*?(?=`"\))" $version
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyFileVersion\(`").*?(?=`"\))" $version
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyInformationalVersion\(`").*?(?=`"\))" $version
}

function RegexReplaceTextInFile($file, $from, $to) {
    $content = [System.IO.File]::ReadAllText($file)
    $content = $content -replace $from, $to
    [System.IO.File]::WriteAllText($file, $content)
}

Main
