using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EasyEditor : Editor
{
    [MenuItem("Custom/GotoSetup")]//快速跳转场景
    public static void GotoSetup()
    {
        EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/SetUp.unity");
        //EditorApplication.OpenScene(Application.dataPath + "/Scenes/UIEditor.unity");
    }

    //把配置文件放在Resources目录下
    [MenuItem("Custom/ConfigToResources")]
    public static void ConfigToResources()
    {
        //找到目标路径和原路径
        //清空目标路径
        //复制，加后缀
        //刷新文件数据，生成meta
        var srcPath = Application.dataPath + "/../Config/";//一定要在前面加下划线
        var dstPath = Application.dataPath + "/Resources/Config/";

        //删掉目录重导
        Directory.Delete(dstPath,true);
        Directory.CreateDirectory(dstPath);

        foreach (var filePath in Directory.GetFiles(srcPath)) 
        {
            var fileName = filePath.Substring(filePath.LastIndexOf('/')+1);//从路径找到最后一个斜杆后的文件名
            File.Copy(filePath,dstPath + fileName + ".bytes",true);//为什么不删.csv,因为方便直接加后缀|||||允许重写
        }

        AssetDatabase.Refresh();//刷新，生成meta文件

        Debug.Log("导表配置文件复制完成");
    }
}
