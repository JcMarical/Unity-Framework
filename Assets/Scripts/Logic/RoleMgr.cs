
using UnityEngine;

/// <summary>
/// 角色管理器
/// </summary>
public class RoleMgr: Singleton<RoleMgr>//90%可能性都是单例模式，不是单独的单例也是一个单例的子模块
{
    private int _mainRoleThisID;//保存主角色ID
    internal static void OnMainRoleThisID(Cmd cmd)
    {
        //首先，检查消息是否合法
        if( Net.CheckCmd(cmd,typeof(MainRoleThisIDCmd)) ){return;;}
        MainRoleThisIDCmd thisIDCmd = cmd as MainRoleThisIDCmd;
        RoleMgr.Instance._mainRoleThisID = thisIDCmd.ThisID; //静态类变量需要使用实例的变量来访问
    }

    internal static void OnCreateSceneRole(Cmd cmd)
    {
        //首先，检查消息是否合法
        if( Net.CheckCmd(cmd,typeof(CreateSceneRoleCmd)) ){return;;}
        CreateSceneRoleCmd createRole = cmd as CreateSceneRoleCmd;

        Debug.LogError(createRole);
        //静态类变量需要使用实例的变量来访问
    }
}
