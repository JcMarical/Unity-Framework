using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Singleton<Server>,IServer
{
    //����֧��һ���ͻ���
    IClient _client;

    //��Ϣ���ͣ������ַ�
    Dictionary<Type,Action<Cmd>> _parser = new Dictionary<Type,Action<Cmd>>();

    /// <summary>
    /// ��ǰ��¼�����ĸ���ң���ʱֻ����һ�����
    /// </summary>
    public Player CurPlayer;

    public Server()
    {
        //���ý������������
        _parser.Add(typeof(LoginCmd),CmdParser.OnLogin);
        _parser.Add(typeof(SelectRoleCmd),CmdParser.OnSelectRole);
    }
    public void Connect(IClient client)
    {
        _client = client;
    }

    public void Receive(Cmd cmd)
    {
        //_client.send
        Debug.Log("�������յ���Ϣ" + cmd.GetType());
        //�ַ���Ϣ
        Action<Cmd> func;
        //�ҵ���Ϣ���ͣ�������Ϣ����
        if(_parser.TryGetValue(cmd.GetType(), out func))
        {
            if(func != null)
            {
                func(cmd);
            }
        }
    }

    public void SendCmd(Cmd cmd)
    {
        _client.Receive(cmd);
    }


}
