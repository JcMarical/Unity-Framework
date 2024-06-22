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
//选择的角色 C-->S
public class SelectRoleCmd : Cmd
{
    //角色索引
    public int Index;
}

//选人界面角色结构，要和RoleList一起发出去
public class SelectRoleInfo
{
    public string Name;         //角色名
    //public string ModelResPath; //模型资源路径
    public int ModelID;
}