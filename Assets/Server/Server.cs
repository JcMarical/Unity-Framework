using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Singleton<Server>,IServer
{
    //暂且支持一个客户端
    IClient _client;

    //消息类型，解析分发
    Dictionary<Type,Action<Cmd>> _parser = new Dictionary<Type,Action<Cmd>>();

    /// <summary>
    /// 当前登录的是哪个玩家，暂时只保留一个玩家
    /// </summary>
    public Player CurPlayer;

    public Server()
    {
        //调用解析类解析函数
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
        Debug.Log("服务器收到消息" + cmd.GetType());
        //分发消息
        Action<Cmd> func;
        //找到消息类型，调用消息函数
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
