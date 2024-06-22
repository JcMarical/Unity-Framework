//用户数据
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 选人界面角色结构
/// </summary>
public class UserData:Singleton<UserData>
{
    public List<SelectRoleInfo> AllRole =  new List<SelectRoleInfo>();
    internal static void OnRoleList(Cmd cmd)
    {
        RoleListCmd roleListCmd = cmd as RoleListCmd;
        if (roleListCmd ==  null)
        {
           
            Debug.LogError(string.Format("需要{0},但是收到了{1}", typeof(RoleListCmd), cmd.GetType()));
            return;
        }
        else
        {
            Debug.Log(string.Format("需要{0},收到了{1}", typeof(RoleListCmd), cmd.GetType()) ); 
        }

        //收到消息后，给角色列表赋值
        UserData.Instance.AllRole = roleListCmd.AllRole;

        if(roleListCmd.AllRole.Count >0)
        {
            //选人界面
            SceneManager.LoadScene("SelectRole");
        }
        else
        {
            //创建界面

            SceneManager.LoadScene("CreateRole");
        }
    }
    /*
    //假的数据
    public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();

     public UserData()
    {
        
        ///初始化角色列表
        AllRole.Add(new SelectRoleInfo() { Name = "第一个角色",ModelResPath = "Prefabs/Role/Character1"});
        AllRole.Add(new SelectRoleInfo() { Name = "2",ModelResPath = "Prefabs/Role/Character2" });
        AllRole.Add(new SelectRoleInfo() { Name = "3",ModelResPath = "Prefabs/Role/Character3" });
    }
    */
}