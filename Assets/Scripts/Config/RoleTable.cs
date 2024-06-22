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
    // id, 数据条目
    //Dictionary<int,RoleDatabase> _cache = new Dictionary<int,RoleDatabase>();

    public RoleTable() {

        //读表
        load("Config/RoleTable.csv");
        
        /*
        //Config/RoleTable/csv，utf8文件可以直接用TextAsset，二进制则需要转换一下
        var table = Resources.Load<TextAsset>("Config/RoleTable.csv");
        //创建内存流
        var tableStream = new MemoryStream(table.bytes);

        //使用using后会自动关闭流
        using(var reader = new StreamReader(tableStream, Encoding.GetEncoding("gb2312"))){
            //跳过第一行内容
            reader.ReadLine();
            //下面是正式数据
            var lineStr = reader.ReadLine();
            while(lineStr != null)
            {
                //读到内存,逗号划分
                var itemStrArray = lineStr.Split(',');
                var roleDB = new RoleDatabase();
                //给数据结构赋值
                roleDB.ID = int.Parse(itemStrArray[0]);
                roleDB.Name = itemStrArray[1];
                roleDB.ModelPath = itemStrArray[2];

                _cache[roleDB.ID] = roleDB;
                //循环
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
    //获取表格数据
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
