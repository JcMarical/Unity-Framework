using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IClient
{
    void SendCmd(Cmd cmd);
    void Receive(Cmd cmd);
}

public interface IServer
{
    void Connect(IClient client);
    void SendCmd(Cmd cmd);
    void Receive(Cmd cmd);
}
public class Net : Singleton<Net>, IClient
{
    IServer _server;

    //��Ϣ���ͣ���Ϣ��������
    Dictionary<Type,Action<Cmd>> _parser = new Dictionary<Type,Action<Cmd>>();

    public Net()
    {
        _parser.Add(typeof(RoleListCmd), UserData.OnRoleList);
        //��ӽ�ɫ�б�

    }

    public void ConnectServer(Action successCallback,Action failedCallback)//�ص�����
    {
        _server = Server.Instance;
        _server.Connect(this);//�÷����������Լ����Լ�������ǿͻ���

        if (true)
        {
            if (successCallback != null)
            {
                successCallback();
                Debug.Log("���ӳɹ�");
            }
            else
            {
                if (failedCallback != null)
                {
                    failedCallback();
                }
            }
        }
    }
    public void Receive(Cmd cmd)
    {
       // _server.send();
       Debug.Log("�ͻ����յ���Ϣ" + cmd.GetType());
        Action<Cmd> func;
        if(_parser.TryGetValue(cmd.GetType(), out func)) { 
            if(func != null) { func(cmd); }
        }
    }

    public void SendCmd(Cmd cmd)
    {
        //�ͻ��˷���Ϣ==����������Ϣ
        _server.Receive(cmd);
    }

    public static bool CheckCmd(Cmd cmd,Type targetType)
    {
        //Debug.Log("�ַ�LoginCmd�ɹ�");
        if(cmd.GetType() != targetType)
        {
            Debug.LogError(string.Format("��Ҫ{0},�����յ���{1}", targetType, cmd.GetType()));
            return false;
        }
        return true;
    }
}
