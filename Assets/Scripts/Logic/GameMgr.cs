using System;
using UnityEngine;

public class GameMgr : Singleton<GameMgr>
{


    internal void Init()
    {
        //启动游戏引擎
        //跳转第一个逻辑界面
        Application.LoadLevel("Login");

    }
}