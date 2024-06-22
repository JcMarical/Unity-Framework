using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//资源管理器。加载方式和使用逻辑分离
//以便于支持：热更新、对象池
public class ResMgr : Singleton<ResMgr>
{
    /// <summary>
    /// 根据路径直接获取实例
    /// </summary>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public GameObject GetInstance(string resPath)
    {
       return  GameObject.Instantiate(GetResources<GameObject>(resPath));
    }
    /// <summary>
    /// 根据路径获取资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public T GetResources<T>(string resPath) where T : UnityEngine.Object
    {
        return Resources.Load<T>(resPath);
    }
}
