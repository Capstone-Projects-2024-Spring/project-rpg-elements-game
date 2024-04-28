using System;
using UnityEditor;
using UnityEngine;

public class BuildScript: MonoBehaviour
{
    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        BuildWindowsClient();
        BuildLinuxServer();

    }
    [MenuItem("Build/Build Client (Windows)")]
    public static void BuildWindowsClient()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Levels/MainMenu/MainMenu", "Assets/Levels/LevelGenerator.unity" };
        buildPlayerOptions.locationPathName = "Builds/Windows/Client/Wildlife Odyssey.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;

        Console.WriteLine("Building Client (Windows)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Client (Windows).");
    }


    [MenuItem("Build/Build Server (Linux)")]
    public static void BuildLinuxServer()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Levels/LevelGenerator.unity" },
            locationPathName = "Builds/Linux/Server/Server.x86_64",
            target = BuildTarget.StandaloneLinux64,
            options = BuildOptions.CompressWithLz4HC | BuildOptions.EnableHeadlessMode
        };

        Console.WriteLine("Building Server (Linux)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Server (Linux).");
    }


    //[MenuItem("Build/Build Server (Windows)")]
    //public static void BuildWindowsServer()
    //{
    //    BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
    //    buildPlayerOptions.scenes = new[] { "Assets/Scenes/Main.unity" };
    //    buildPlayerOptions.locationPathName = "Builds/Windows/Server/Server.exe";
    //    buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
    //    buildPlayerOptions.options = BuildOptions.CompressWithLz4HC | BuildOptions.EnableHeadlessMode;

    //    Console.WriteLine("Building Server (Windows)...");
    //    BuildPipeline.BuildPlayer(buildPlayerOptions);
    //    Console.WriteLine("Built Server (Windows).");
    //}

}