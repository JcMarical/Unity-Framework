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


//表格基类
public class ConfigTable<TDatabase, T> :Singleton<T> 
    where TDatabase : TableDatabase,new()//必须为TDatabase类型，需要new约束(需要放在最后)，才能创建对象
    where T : new() //第二个参数的约束
{
    // id, 数据条目
    Dictionary<int, TDatabase> _cache = new Dictionary<int, TDatabase>();

    protected void load(string tablePath)
    {
        MemoryStream tableStream;

        //开发期，读Project/Config
#if UNITY_EDITOR
        var srcPath = Application.dataPath + "/../" + tablePath;
        tableStream = new MemoryStream(File.ReadAllBytes(srcPath));
#else

        //发布之后，读Resources/Config
        //读表（二进制方式）
        //Config/RoleTable/csv，utf8文件可以直接用TextAsset，
        var table = Resources.Load<TextAsset>(tablePath);
        tableStream = new MemoryStream(table.bytes);
#endif

        using (var reader = new StreamReader(tableStream, Encoding.GetEncoding("gb2312")))
        {
            //字段名
            var fieldNameStr = reader.ReadLine();
            var fieldNameArray = fieldNameStr.Split(",");
            List<FieldInfo> allFieldInfo = new List<FieldInfo>();

            foreach (var fieldName in fieldNameArray)
            {

                allFieldInfo.Add(typeof(TDatabase).GetField(fieldName));
            }


            //下面是正式数据
            var lineStr = reader.ReadLine();
            while (lineStr != null)
            {
               TDatabase curDB = readline(allFieldInfo,lineStr);

                /*
                 * 有反射就不需要了
                 * =========================
                //给数据结构赋值
                TDB.ID = int.Parse(itemStrArray[0]);
                //解析其他数据
                praserItem(TDB, itemStrArray);
                //roleDB.Name = itemStrArray[1];
                //roleDB.ModelPath = itemStrArray[2];
                */  
                _cache[curDB.ID] = curDB;
                //循环
                lineStr = reader.ReadLine();
            }
        }

    }

    private static TDatabase readline(List<FieldInfo> allFieldInfo, string lineStr)
    {
        //读到内存,逗号划分
        var itemStrArray = lineStr.Split(',');
        var TDB = new TDatabase();

        //解析:对每个字段
        //---------------
        //foreach()...不能保证遍历顺序
        for (int i = 0; i < allFieldInfo.Count; ++i)
        {
            var field = allFieldInfo[i];//key
            var data = itemStrArray[i];//value

            //解析区分:还需要更多的类型解析 int,float,string,bool,Array(List)
            if (field.FieldType == typeof(int))
            {
                field.SetValue(TDB, int.Parse(data));//如果是数值，就将字符串转换成数值
            }
            else if (field.FieldType == typeof(string))
            {
                field.SetValue(TDB, data);
            }
            else if (field.FieldType == typeof(float))
            {
                field.SetValue(TDB, float.Parse(data));//如果是数值，就将字符串转换成数值
            }
            else if (field.FieldType == typeof(bool))
            {
                var v = int.Parse(data);
                field.SetValue(TDB, v != 0);//1->True,0->False
                                            //    field.SetValue(TDB, bool.Parse(data));//如果是数值，就将字符串转换成数值
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

    //获取表格数据
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




    //数据存储方式

    //表的获取方式


    //不同
    //数据类型不同
    //文件路径不同
}
