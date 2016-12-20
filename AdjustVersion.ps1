$newVersion = "0.6.1"

function Main() {
    RegexReplaceTextInFile "CreateArtefacts.ps1" "(?<=\`$version = `").*?(?=`")" $newVersion
    RegexReplaceTextInFile "src\FlaUInspect\FlaUInspect.nuspec" "(?<=<version>).*?(?=</version>)" $newVersion

    ReplaceAssemblyVersion "src\FlaUI.Core\Properties\AssemblyInfo.cs" $newVersion
    ReplaceAssemblyVersion "src\FlaUI.UIA2\Properties\AssemblyInfo.cs" $newVersion
    ReplaceAssemblyVersion "src\FlaUI.UIA3\Properties\AssemblyInfo.cs" $newVersion
    ReplaceAssemblyVersion "src\FlaUInspect\Properties\AssemblyInfo.cs" $newVersion
}

function RegexReplaceTextInFile($file, $from, $to) {
    $content = [System.IO.File]::ReadAllText($file)
    $content = $content -replace $from, $to
    [System.IO.File]::WriteAllText($file, $content)
}

function ReplaceAssemblyVersion($assemblyFile, $version) {
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyVersion\(`").*?(?=`"\))" $version
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyFileVersion\(`").*?(?=`"\))" $version
    RegexReplaceTextInFile $assemblyFile "(?<=AssemblyInformationalVersion\(`").*?(?=`"\))" $version
}

Main