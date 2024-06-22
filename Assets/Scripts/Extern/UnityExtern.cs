using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtern 
{
    /// <summary>
    /// �ҵ��ö����µ���·���Ķ�Ӧ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T Find<T>(this GameObject parent,string path)
    {
       return parent.transform.Find(path).GetComponent<T>(); 
    }


    /// <summary>
    /// ɾ�����е��ӽڵ�
    /// </summary>
    /// <param name="parent"></param>
    public static void DestroyAllChildren(this GameObject parent)
    {
        //����1
        //
        for (int i = 0; i < parent.transform.childCount; ++i)
        {
            var child = parent.transform.GetChild(i);
            GameObject.Destroy(child.gameObject);
        }

        //����2(Ϊʲô�Ҳ�����������˸����壿)
        //foreach (var child in parent.transform.GetComponentsInChildren<Transform>())
        //{
          //  GameObject.Destroy(child.gameObject);
        //}
        //
    }
}
