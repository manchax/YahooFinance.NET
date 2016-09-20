#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#tool "nuget:?package=xunit.runner.console"


var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


// Define directories.
var buildDir = Directory("./YahooFinance.NET/bin") + Directory(configuration);
var buildTestDir = Directory("./YahooFinance.NET.Tests/bin") + Directory(configuration);


Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
    CleanDirectory(buildTestDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./YahooFinance.NET.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
      MSBuild("./YahooFinance.NET.sln", settings =>
        settings.SetConfiguration(configuration));
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    XUnit2(buildTestDir.ToString() + "/*.Tests.dll");
});


Task("Default")
    .IsDependentOn("Test");


RunTarget(target);
