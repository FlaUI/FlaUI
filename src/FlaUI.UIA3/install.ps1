param($installPath, $toolsPath, $package, $project)

$project.Object.References | Where-Object { $_.EmbedInteropTypes -eq $true -and $_.Name -eq "Interop.UIAutomationClient" } |  ForEach-Object { $_.EmbedInteropTypes = $false }
$project.Save()