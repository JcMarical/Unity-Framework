using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

public class TableDatabase
{
    public int ID;
    public string ModelPath;
    public List<int> TestIDList;
}


//������
public class ConfigTable<TDatabase, T> :Singleton<T> 
    where TDatabase : TableDatabase,new()//����ΪTDatabase���ͣ���ҪnewԼ��(��Ҫ�������)�����ܴ�������
    where T : new() //�ڶ���������Լ��
{
    // id, ������Ŀ
    Dictionary<int, TDatabase> _cache = new Dictionary<int, TDatabase>();

    protected void load(string tablePath)
    {
        MemoryStream tableStream;

        //�����ڣ���Project/Config
#if UNITY_EDITOR
        var srcPath = Application.dataPath + "/../" + tablePath;
        tableStream = new MemoryStream(File.ReadAllBytes(srcPath));
#else

        //����֮�󣬶�Resources/Config
        //���������Ʒ�ʽ��
        //Config/RoleTable/csv��utf8�ļ�����ֱ����TextAsset��
        var table = Resources.Load<TextAsset>(tablePath);
        tableStream = new MemoryStream(table.bytes);
#endif

        using (var reader = new StreamReader(tableStream, Encoding.GetEncoding("gb2312")))
        {
            //�ֶ���
            var fieldNameStr = reader.ReadLine();
            var fieldNameArray = fieldNameStr.Split(",");
            List<FieldInfo> allFieldInfo = new List<FieldInfo>();

            foreach (var fieldName in fieldNameArray)
            {

                allFieldInfo.Add(typeof(TDatabase).GetField(fieldName));
            }


            //��������ʽ����
            var lineStr = reader.ReadLine();
            while (lineStr != null)
            {
               TDatabase curDB = readline(allFieldInfo,lineStr);

                /*
                 * �з���Ͳ���Ҫ��
                 * =========================
                //�����ݽṹ��ֵ
                TDB.ID = int.Parse(itemStrArray[0]);
                //������������
                praserItem(TDB, itemStrArray);
                //roleDB.Name = itemStrArray[1];
                //roleDB.ModelPath = itemStrArray[2];
                */  
                _cache[curDB.ID] = curDB;
                //ѭ��
                lineStr = reader.ReadLine();
            }
        }

    }

    private static TDatabase readline(List<FieldInfo> allFieldInfo, string lineStr)
    {
        //�����ڴ�,���Ż���
        var itemStrArray = lineStr.Split(',');
        var TDB = new TDatabase();

        //����:��ÿ���ֶ�
        //---------------
        //foreach()...���ܱ�֤����˳��
        for (int i = 0; i < allFieldInfo.Count; ++i)
        {
            var field = allFieldInfo[i];//key
            var data = itemStrArray[i];//value

            //��������:����Ҫ��������ͽ��� int,float,string,bool,Array(List)
            if (field.FieldType == typeof(int))
            {
                field.SetValue(TDB, int.Parse(data));//�������ֵ���ͽ��ַ���ת������ֵ
            }
            else if (field.FieldType == typeof(string))
            {
                field.SetValue(TDB, data);
            }
            else if (field.FieldType == typeof(float))
            {
                field.SetValue(TDB, float.Parse(data));//�������ֵ���ͽ��ַ���ת������ֵ
            }
            else if (field.FieldType == typeof(bool))
            {
                var v = int.Parse(data);
                field.SetValue(TDB, v != 0);//1->True,0->False
                                            //    field.SetValue(TDB, bool.Parse(data));//�������ֵ���ͽ��ַ���ת������ֵ
            }
            else if (field.FieldType == typeof(List<int>))
            {
                var list = new List<int>();
                foreach (var itemStr in data.Split('$'))
                {
                    list.Add(int.Parse(itemStr));
                }
                field.SetValue(TDB, list);
            }
            else if (field.FieldType == typeof(List<float>))
            {
                var list = new List<float>();
                foreach (var itemStr in data.Split('$'))
                {
                    list.Add(float.Parse(itemStr));
                }
                field.SetValue(TDB, list);
            }
            else if (field.FieldType == typeof(List<string>))
            {
                /*
                var list = new List<string>();
                foreach (var itemStr in data.Split('$'))
                {
                    list.Add(itemStr);
                }
                field.SetValue(TDB, list);
           */

                field.SetValue(TDB, new List<string>(data.Split("$")));
            }

        }
        return TDB;
    }
    /*
    protected virtual void praserItem(TDatabase database, string[] itemStrArray)
    {

    }
    */

    //��ȡ�������
    public TDatabase this[int id]
    {
        get
        {
            TDatabase db;
            _cache.TryGetValue(id, out db);
            return db;
        }
    }

    public Dictionary<int, TDatabase> GetAll()
    {
        return _cache;
    }




    //���ݴ洢��ʽ

    //��Ļ�ȡ��ʽ


    //��ͬ
    //�������Ͳ�ͬ
    //�ļ�·����ͬ
}
