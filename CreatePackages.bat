SET config=Release
SET output=Packages
msbuild src\
mkdir %output%
nuget pack "src\FlaUI.Core\FlaUI.Core.csproj" -Properties "Configuration=%config%;Platform=AnyCPU" -IncludeReferencedProjects -OutputDirectory "%output%"
nuget pack "src\FlaUI.UIA2\FlaUI.UIA2.csproj" -Properties "Configuration=%config%;Platform=AnyCPU" -IncludeReferencedProjects -OutputDirectory "%output%"
nuget pack "src\FlaUI.UIA3\FlaUI.UIA3.csproj" -Properties "Configuration=%config%;Platform=AnyCPU" -IncludeReferencedProjects -OutputDirectory "%output%"
choco pack "src\FlaUInspect\FlaUInspect.nuspec" -OutputDirectory "%output%"
pause
