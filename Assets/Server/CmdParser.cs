using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// δ����ģ�����Ϣ����
public static class CmdParser 
{
    public static void OnLogin(Cmd cmd)
    {
        //Debug.Log("�ַ�LoginCmd�ɹ�");

        //cmd�����ͱ�����LoginCmd(ʹ��asǿ��ת��)
        LoginCmd loginCmd = cmd as LoginCmd;
        //������ɹ��򷵻�
        if(loginCmd == null)
        {
            Debug.LogError( string.Format("��Ҫ{0},�����յ���{1}", typeof(LoginCmd), cmd.GetType()) );
            return;
        }



        // ��֤�˺�����
        // �ҵ���Ҵ浵


        Server.Instance.CurPlayer = new Player();
        var player = Server.Instance.CurPlayer; //����������ʱ��������һ��
        //��������
        RoleListCmd roleListCmd = new RoleListCmd();


        //roleListCmd.AllRole = player.AllRole.GetRange(0, player.AllRole.Count);          //ע�������[ǳ����]
        //��Ҫ��"���"
        foreach(var  role in player.AllRole) 
        {
            //ÿ��������newһ��
            var roleInfo = new SelectRoleInfo()
            {
                Name = role.Name,
                ModelID = role.ModelID,
            };

            roleListCmd.AllRole.Add(roleInfo);
        }

        Server.Instance.SendCmd(roleListCmd);
        // ��ͻ��˷�������Ѵ����Ľ�ɫ�б�


    }

    internal static void OnSelectRole(Cmd cmd)
    {
        LoginCmd loginCmd = cmd as LoginCmd;

    }
}
