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

    //消息类型，消息解析函数
    Dictionary<Type,Action<Cmd>> _parser = new Dictionary<Type,Action<Cmd>>();

    public Net()
    {
        _parser.Add(typeof(RoleListCmd), UserData.OnRoleList);
        //添加角色列表

    }

    public void ConnectServer(Action successCallback,Action failedCallback)//回调函数
    {
        _server = Server.Instance;
        _server.Connect(this);//让服务器调用自己，自己本身就是客户端

        if (true)
        {
            if (successCallback != null)
            {
                successCallback();
                Debug.Log("连接成功");
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
       Debug.Log("客户端收到消息" + cmd.GetType());
        Action<Cmd> func;
        if(_parser.TryGetValue(cmd.GetType(), out func)) { 
            if(func != null) { func(cmd); }
        }
    }

    public void SendCmd(Cmd cmd)
    {
        //客户端发消息==服务器收消息
        _server.Receive(cmd);
    }

    public static bool CheckCmd(Cmd cmd,Type targetType)
    {
        //Debug.Log("分发LoginCmd成功");
        if(cmd.GetType() != targetType)
        {
            Debug.LogError(string.Format("需要{0},但是收到了{1}", targetType, cmd.GetType()));
            return false;
        }
        return true;
    }
}
