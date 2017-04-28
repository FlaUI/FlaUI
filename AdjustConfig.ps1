$newVersion = "1.1.0"
$suffix = ""

function Main() {
	ReplaceVersion
}

function ReplaceVersion {
	RegexReplaceTextInFile "CreateArtefacts.ps1" "(?<=\`$version = `").*?(?=`")" "$($newVersion)$($suffix)"

    ReplaceAssemblyVersion "src\FlaUI.Core\Properties\AssemblyInfo.cs"
    ReplaceAssemblyVersion "src\FlaUI.UIA2\Properties\AssemblyInfo.cs"
    ReplaceAssemblyVersion "src\FlaUI.UIA3\Properties\AssemblyInfo.cs"
    ReplaceAssemblyVersion "src\FlaUInspect\Properties\AssemblyInfo.cs"
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
