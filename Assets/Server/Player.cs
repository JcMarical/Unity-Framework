using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
//选人界面角色结构
public class SelectRoleInfo
{
    public string Name;     //角色名
    public string ModelResPath;  //模型资源路径
}
*/

// 表示玩家
public class Player 
{
    //假的角色数据
    public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();

    /*
    public Player()
    {
        AllRole.Add(new SelectRoleInfo() { Name = "第一个角色", ModelResPath = "Prefabs/Role/Character1" });
        AllRole.Add(new SelectRoleInfo() { Name = "2", ModelResPath = "Prefabs/Role/Character2" });
        AllRole.Add(new SelectRoleInfo() { Name = "3", ModelResPath = "Prefabs/Role/Character3" });
    }
    */
    public Player()
    {
        AllRole.Add(new SelectRoleInfo() { Name = "第一个角色", ModelID = 1 });
        AllRole.Add(new SelectRoleInfo() { Name = "2", ModelID = 2 });
        AllRole.Add(new SelectRoleInfo() { Name = "3", ModelID = 3 });
    }
}
