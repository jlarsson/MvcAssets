properties {
	$base_dir = resolve-path .
	$build_configuration = "Release"
	$build_platform = "Any CPU"
	$build_dir = join-path $base_dir "build\4.0\"
	$build_properties = "OutDir=$build_dir;Configuration=$build_configuration;Platform=$build_platform"
	$pack_dir = join-path $base_dir "build\packs"
	$solutions = ("MvcAssets.sln")

	$mvcassets = Create-Project-Description `
		-base_dir $base_dir `
		-project_name "MvcAssets" `
		-id "MvcAssets" `
		-author "Joakim Larsson" `
		-description "Asset manager for Asp.NET MVC 3" `
		-copyright "Copyright � Joakim Larsson 2011"

	$aspnetassets = Create-Project-Description `
		-base_dir $base_dir `
		-project_name "AspNetAssets" `
		-id "AspNetAssets" `
		-author "Joakim Larsson" `
		-description "Asset manager for Asp.NET" `
		-copyright "Copyright � Joakim Larsson 2011"

	$projects = ($mvcassets, $aspnetassets)
}

$framework = '4.0'

include .\psake_ext.ps1

task default -depends pack

task clean {
	remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
}

task update-assembly-info -depends clean {
	$projects | foreach { (Generate-Assembly-Info $_) }
}

task build -depends update-assembly-info {
	$solutions | foreach { msbuild $_ /target:Build /nologo /verbosity:quiet /p:$build_properties }
}

task pack -depends build {
	Ensure-Directory $pack_dir
	$projects | foreach { `
		$p = $_
		$copy_folders = ("tools","content")
		$copy_folders | foreach { Copy-Item  -path  (join-path $p.project_dir $_) -destination $build_dir -force  -recurse -ErrorAction SilentlyContinue }
		$props = "id=$($p.id);version=$($p.version);title=$($p.title);author=$($p.author);description=$($p.description);copyright=$($p.copyright);root=$($build_dir);"
		(.nuget\nuget pack $p.nuspec_file `
			-p $props `
			-basePath $build_dir `
			-o $pack_dir) `
	}
}
