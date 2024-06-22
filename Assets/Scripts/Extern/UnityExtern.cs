using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtern 
{
    /// <summary>
    /// 找到该对象下的子路径的对应组件
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
    /// 删除所有的子节点
    /// </summary>
    /// <param name="parent"></param>
    public static void DestroyAllChildren(this GameObject parent)
    {
        //方法1
        //
        for (int i = 0; i < parent.transform.childCount; ++i)
        {
            var child = parent.transform.GetChild(i);
            GameObject.Destroy(child.gameObject);
        }

        //方法2(为什么我测出来还包含了父物体？)
        //foreach (var child in parent.transform.GetComponentsInChildren<Transform>())
        //{
          //  GameObject.Destroy(child.gameObject);
        //}
        //
    }
}
