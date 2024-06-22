using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
//ѡ�˽����ɫ�ṹ
public class SelectRoleInfo
{
    public string Name;     //��ɫ��
    public string ModelResPath;  //ģ����Դ·��
}
*/

// ��ʾ���
public class Player 
{
    //�ٵĽ�ɫ����
    public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();

    /*
    public Player()
    {
        AllRole.Add(new SelectRoleInfo() { Name = "��һ����ɫ", ModelResPath = "Prefabs/Role/Character1" });
        AllRole.Add(new SelectRoleInfo() { Name = "2", ModelResPath = "Prefabs/Role/Character2" });
        AllRole.Add(new SelectRoleInfo() { Name = "3", ModelResPath = "Prefabs/Role/Character3" });
    }
    */
    public Player()
    {
        AllRole.Add(new SelectRoleInfo() { Name = "��һ����ɫ", ModelID = 1 });
        AllRole.Add(new SelectRoleInfo() { Name = "2", ModelID = 2 });
        AllRole.Add(new SelectRoleInfo() { Name = "3", ModelID = 3 });
    }
}
