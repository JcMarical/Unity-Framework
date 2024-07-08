using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//消息基类
public class Cmd 
{

}


public class LoginCmd : Cmd 
{
    public string Account;
    public string Password;
}

//玩家的角色列表 S-->C
public class RoleListCmd:Cmd
{
    //list 保存玩家所有角色、
    public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();

}


//选人界面角色结构，要和RoleList一起发出去
public class SelectRoleInfo
{
    public string Name;         //角色名
    //public string ModelResPath; //模型资源路径
    public int ModelID;
}

//选择的角色 C-->S
public class SelectRoleCmd : Cmd
{
    //角色索引
    public int Index;
}

/// <summary>
/// 主角ThisID S-->C
/// </summary>
public class MainRoleThisIDCmd : Cmd
{
    //角色唯一标识
    public int ThisID;

}

public class EnterMapCmd : Cmd
{
    public int MapID;
}

/// <summary>
/// 创建角色
/// </summary>
public class CreateSceneRoleCmd : Cmd
{
    public int ThisID; //角色的唯一标识：服务器和客户端辨别一个角色的唯一标识
    public string Name; //角色名
    public int ModelID; //模型ID
    
    public Vector3 Pos; //角色出生位置
    public Vector3 FaceTo; //角色出生朝向
}