using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��Դ�����������ط�ʽ��ʹ���߼�����
//�Ա���֧�֣��ȸ��¡������
public class ResMgr : Singleton<ResMgr>
{
    /// <summary>
    /// ����·��ֱ�ӻ�ȡʵ��
    /// </summary>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public GameObject GetInstance(string resPath)
    {
       return  GameObject.Instantiate(GetResources<GameObject>(resPath));
    }
    /// <summary>
    /// ����·����ȡ��Դ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public T GetResources<T>(string resPath) where T : UnityEngine.Object
    {
        return Resources.Load<T>(resPath);
    }
}
