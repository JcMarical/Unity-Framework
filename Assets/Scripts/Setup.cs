using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public void Awake()
    {
        //���������¡���󵽵�¼
        GameMgr.Instance.Init();

        Debug.Log(RoleTable.Instance[3].Name);
    }

    
}
