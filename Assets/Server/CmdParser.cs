using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 未划分模块的消息解析
public static class CmdParser 
{
    public static void OnLogin(Cmd cmd)
    {
        //Debug.Log("分发LoginCmd成功");

        //cmd的类型必须是LoginCmd(使用as强制转换)
        /*
        LoginCmd loginCmd = cmd as LoginCmd;
        //如果不成功则返回
        if(loginCmd == null)
        {
            Debug.LogError( string.Format("需要{0},但是收到了{1}", typeof(LoginCmd), cmd.GetType()) );
            return;
        }
        */

        //上面改为下面，cmd的类型必须是LoginCmd
        if (!Net.CheckCmd(cmd, typeof(LoginCmd))) 
        {
            return;
        }


        // 验证账号密码
        // 找到玩家存档


        Server.Instance.CurPlayer = new Player();
        var player = Server.Instance.CurPlayer; //长变量用临时变量保存一下
        //创建命令
        RoleListCmd roleListCmd = new RoleListCmd();


        //roleListCmd.AllRole = player.AllRole.GetRange(0, player.AllRole.Count);          //注意这个是[浅拷贝]
        //需要用"深拷贝"
        foreach(var  role in player.AllRole) 
        {
            //每个都重新new一遍
            var roleInfo = new SelectRoleInfo()
            {
                Name = role.Name,
                ModelID = role.ModelID,
            };

            roleListCmd.AllRole.Add(roleInfo);
        }

        Server.Instance.SendCmd(roleListCmd);
        // 向客户端发送玩家已创建的角色列表
    }

    internal static void OnSelectRole(Cmd cmd)
    {
        if (!Net.CheckCmd(cmd, typeof(SelectRoleCmd)))
        {
            return;
        } 
        
        // 选择角色
        SelectRoleCmd selectRoleCmd = cmd as SelectRoleCmd;
        
        var curPlayer = Server.Instance.CurPlayer;
        SelectRoleInfo curRoleInfo = Server.Instance.CurPlayer.AllRole[selectRoleCmd.Index];

        //----------设置角色信息--------
        //告诉客户端，场景编号
        var sceneID = 1;
        EnterMapCmd enterMapCmd = new EnterMapCmd() { MapID = sceneID };
        //分配ThisID
        var thisid = RoleServer.GetNewThisID();
        //告诉客户端主角的ThisID
        MainRoleThisIDCmd thisIdCmd = new MainRoleThisIDCmd() { ThisID = thisid };
        //生成主角
        CreateSceneRoleCmd roleCmd = new CreateSceneRoleCmd();
        roleCmd.ThisID = thisid;
        roleCmd.Name = curRoleInfo.Name;
        roleCmd.ModelID = curRoleInfo.ModelID;
        roleCmd.Pos = Vector3.zero;
        roleCmd.FaceTo = Vector3.forward;

        Server.Instance.SendCmd(enterMapCmd);
        Server.Instance.SendCmd(thisIdCmd);
        Server.Instance.SendCmd(roleCmd);
        
        
        //生产附近的配角(暂定)
        //生成附近的NPC
        //CreateSceneRole
        //----------------------------
    }
}
