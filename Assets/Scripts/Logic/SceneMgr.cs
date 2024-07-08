using UnityEngine;

/// <summary>
/// 场景管理器
/// </summary>
    public class SceneMgr: Singleton<SceneMgr>
    {
        public static void OnEnterMap(Cmd cmd)
        {
            if( Net.CheckCmd(cmd,typeof(EnterMapCmd)) ){return;;}
            EnterMapCmd enterMapCmd = cmd as EnterMapCmd;
            
            Debug.LogError(enterMapCmd);
        }
    }
