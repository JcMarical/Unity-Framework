using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//��Ϣ����
public class Cmd 
{

}


public class LoginCmd : Cmd 
{
    public string Account;
    public string Password;
}

//��ҵĽ�ɫ�б� S-->C
public class RoleListCmd:Cmd
{
    //list ����������н�ɫ��
    public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();

}
//ѡ��Ľ�ɫ C-->S
public class SelectRoleCmd : Cmd
{
    //��ɫ����
    public int Index;
}

//ѡ�˽����ɫ�ṹ��Ҫ��RoleListһ�𷢳�ȥ
public class SelectRoleInfo
{
    public string Name;         //��ɫ��
    //public string ModelResPath; //ģ����Դ·��
    public int ModelID;
}