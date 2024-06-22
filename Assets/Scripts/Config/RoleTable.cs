using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class RoleDatabase:TableDatabase
{
    //public int ID;
    public string Name;
    public string ModelPath;
}


public class RoleTable : ConfigTable<RoleDatabase,RoleTable>
{
    // id, ������Ŀ
    //Dictionary<int,RoleDatabase> _cache = new Dictionary<int,RoleDatabase>();

    public RoleTable() {

        //����
        load("Config/RoleTable.csv");
        
        /*
        //Config/RoleTable/csv��utf8�ļ�����ֱ����TextAsset������������Ҫת��һ��
        var table = Resources.Load<TextAsset>("Config/RoleTable.csv");
        //�����ڴ���
        var tableStream = new MemoryStream(table.bytes);

        //ʹ��using����Զ��ر���
        using(var reader = new StreamReader(tableStream, Encoding.GetEncoding("gb2312"))){
            //������һ������
            reader.ReadLine();
            //��������ʽ����
            var lineStr = reader.ReadLine();
            while(lineStr != null)
            {
                //�����ڴ�,���Ż���
                var itemStrArray = lineStr.Split(',');
                var roleDB = new RoleDatabase();
                //�����ݽṹ��ֵ
                roleDB.ID = int.Parse(itemStrArray[0]);
                roleDB.Name = itemStrArray[1];
                roleDB.ModelPath = itemStrArray[2];

                _cache[roleDB.ID] = roleDB;
                //ѭ��
                lineStr = reader.ReadLine();
            }
        }
        */

    }

    /*
    protected override void praserItem(RoleDatabase roleDB, string[] itemStrArray)
    {
        roleDB.Name = itemStrArray[1];
        roleDB.ModelPath = itemStrArray[2];

    }
    */
    /*
    public RoleDatabase GetData(int id)
    {
        RoleDatabase db;
        _cache.TryGetValue(id, out db);
        return db;
    }
    */

    /*
    //��ȡ�������
    public RoleDatabase this[int id]
    {
        get {
            RoleDatabase db;
            _cache.TryGetValue(id, out db);
            return db;
        }
    }

    public Dictionary<int,RoleDatabase> GetAll()
    {
        return _cache;
    }
    */
}
