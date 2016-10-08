using UnityEngine;
using System.Collections;
using System.IO;

public class ScriptTitleChange : UnityEditor.AssetModificationProcessor
{

    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs"))
        {
            string allText = File.ReadAllText(path);
            allText = allText.Replace("#AUTHOR#", "…ΩπÌ¡Èæµ").Replace("#CREATEDATE#",
                //System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + " " +
                //System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second);
                System.DateTime.Now.ToString());
            File.WriteAllText(path, allText);
        }

    }
}