using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EasyEditor : Editor
{
    [MenuItem("Custom/GotoSetup")]//������ת����
    public static void GotoSetup()
    {
        EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/SetUp.unity");
        //EditorApplication.OpenScene(Application.dataPath + "/Scenes/UIEditor.unity");
    }

    //�������ļ�����ResourcesĿ¼��
    [MenuItem("Custom/ConfigToResources")]
    public static void ConfigToResources()
    {
        //�ҵ�Ŀ��·����ԭ·��
        //���Ŀ��·��
        //���ƣ��Ӻ�׺
        //ˢ���ļ����ݣ�����meta
        var srcPath = Application.dataPath + "/../Config/";//һ��Ҫ��ǰ����»���
        var dstPath = Application.dataPath + "/Resources/Config/";

        //ɾ��Ŀ¼�ص�
        Directory.Delete(dstPath,true);
        Directory.CreateDirectory(dstPath);

        foreach (var filePath in Directory.GetFiles(srcPath)) 
        {
            var fileName = filePath.Substring(filePath.LastIndexOf('/')+1);//��·���ҵ����һ��б�˺���ļ���
            File.Copy(filePath,dstPath + fileName + ".bytes",true);//Ϊʲô��ɾ.csv,��Ϊ����ֱ�ӼӺ�׺|||||������д
        }

        AssetDatabase.Refresh();//ˢ�£�����meta�ļ�

        Debug.Log("���������ļ��������");
    }
}
