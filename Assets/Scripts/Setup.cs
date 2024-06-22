using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public void Awake()
    {
        //闪屏，更新、最后到登录
        GameMgr.Instance.Init();

        Debug.Log(RoleTable.Instance[3].Name);
    }

    
}
