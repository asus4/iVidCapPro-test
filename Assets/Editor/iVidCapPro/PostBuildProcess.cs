using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

public static class PostBuildProcess
{

    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            ProcessForiOS(path);
        }
    }

#if UNITY_IOS
    static void ProcessForiOS(string path)
    {
        // Manual copy for faster iteration
        string plistPath = Path.Combine(path, "Info.plist");
        PlistDocument plist = new PlistDocument();
        plist.ReadFromFile(plistPath);
        PlistElementDict root = plist.root;

        root.SetString("NSPhotoLibraryAddUsageDescription", "Need for saving video files");

        // root.SetBoolean("UIFileSharingEnabled", true);
        // root.SetBoolean("LSSupportsOpeningDocumentsInPlace", true);

        plist.WriteToFile(plistPath);

    }
#else
    static void ProcessForiOS(string path){}
#endif


    static string CombinePaths(params string[] paths)
    {
        return paths.Aggregate(Path.Combine);
    }
}
