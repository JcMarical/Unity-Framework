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


//ѡ�˽����ɫ�ṹ��Ҫ��RoleListһ�𷢳�ȥ
public class SelectRoleInfo
{
    public string Name;         //��ɫ��
    //public string ModelResPath; //ģ����Դ·��
    public int ModelID;
}

//ѡ��Ľ�ɫ C-->S
public class SelectRoleCmd : Cmd
{
    //��ɫ����
    public int Index;
}

/// <summary>
/// ����ThisID S-->C
/// </summary>
public class MainRoleThisIDCmd : Cmd
{
    //��ɫΨһ��ʶ
    public int ThisID;

}

public class EnterMapCmd : Cmd
{
    public int MapID;
}

/// <summary>
/// ������ɫ
/// </summary>
public class CreateSceneRoleCmd : Cmd
{
    public int ThisID; //��ɫ��Ψһ��ʶ���������Ϳͻ��˱��һ����ɫ��Ψһ��ʶ
    public string Name; //��ɫ��
    public int ModelID; //ģ��ID
    
    public Vector3 Pos; //��ɫ����λ��
    public Vector3 FaceTo; //��ɫ��������
}