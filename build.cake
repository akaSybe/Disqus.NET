var target = Argument("target", "Default");

var buildConfiguration = "Release";
var projectName = "Disqus.NET";
var testProjectName = "Disqus.NET.Tests";
var projectFolder = string.Format("./src/{0}/", projectName);
var projectFile = string.Format("./src/{0}/{0}.csproj", projectName);
var testProjectFile = string.Format("./src/{0}/{0}.csproj", testProjectName);

var extensionsVersion = XmlPeek(projectFile, "Project/PropertyGroup[1]/VersionPrefix/text()");

Task("UpdateBuildVersion")
  .WithCriteria(BuildSystem.AppVeyor.IsRunningOnAppVeyor)
  .Does(() =>
{
    var buildNumber = BuildSystem.AppVeyor.Environment.Build.Number;

    BuildSystem.AppVeyor.UpdateBuildVersion(string.Format("{0}.{1}", extensionsVersion, buildNumber));
});

Task("NugetRestore")
  .Does(() =>
{
    DotNetCoreRestore();
});

Task("UpdateAssemblyVersion")
  .Does(() =>
{
    var assemblyFile = string.Format("{0}/Properties/AssemblyInfo.cs", projectFolder);

    AssemblyInfoSettings assemblySettings = new AssemblyInfoSettings();
    assemblySettings.Title = projectName;
    assemblySettings.FileVersion = extensionsVersion;
    assemblySettings.Version = extensionsVersion;
    assemblySettings.InternalsVisibleTo = new [] { testProjectName };

    CreateAssemblyInfo(assemblyFile, assemblySettings);
});

Task("Build")
  .IsDependentOn("NugetRestore")
  .IsDependentOn("UpdateAssemblyVersion")
  .Does(() =>
{
    DotNetBuild(string.Format("{0}.sln", projectName), 
    settings => settings
        .SetConfiguration(buildConfiguration)
        .SetVerbosity(Verbosity.Minimal));
});

Task("Test")
  .IsDependentOn("Build")
  .Does(() =>
{
     var settings = new DotNetCoreTestSettings
     {
         Configuration = buildConfiguration
     };

     DotNetCoreTest(testProjectFile, settings);
});

Task("NugetPack")
  .IsDependentOn("Build")
  .Does(() =>
{
     var settings = new DotNetCorePackSettings
     {
         Configuration = buildConfiguration,
         OutputDirectory = "."
     };

     DotNetCorePack(projectFolder, settings);
});

Task("CreateArtifact")
  .IsDependentOn("NugetPack")
  .WithCriteria(BuildSystem.AppVeyor.IsRunningOnAppVeyor)
  .Does(() =>
{
    BuildSystem.AppVeyor.UploadArtifact(string.Format("{0}.{1}.nupkg", projectName, extensionsVersion));
});

Task("Default")
    .IsDependentOn("Test")
    .IsDependentOn("NugetPack");

Task("CI")
    .IsDependentOn("UpdateBuildVersion")
    .IsDependentOn("CreateArtifact");

RunTarget(target);