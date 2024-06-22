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
        LoginCmd loginCmd = cmd as LoginCmd;
        //如果不成功则返回
        if(loginCmd == null)
        {
            Debug.LogError( string.Format("需要{0},但是收到了{1}", typeof(LoginCmd), cmd.GetType()) );
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
        LoginCmd loginCmd = cmd as LoginCmd;

    }
}
