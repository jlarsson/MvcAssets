param($installPath, $toolsPath, $package, $project)

$path = [System.IO.Path]
$appstart = $path::Combine($path::GetDirectoryName($project.FileName), "App_Start\MvcAssetsPackage.cs")
$layout = $path::Combine($path::GetDirectoryName($project.FileName), "Views\Shared\MvcAssets Layout.cshtml")
$DTE.ItemOperations.OpenFile($layout)
$DTE.ItemOperations.OpenFile($appstart)
