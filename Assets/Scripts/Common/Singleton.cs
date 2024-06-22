
/// <summary>
/// ���͵���,��Instance��ȡ
/// </summary>
/// <typeparam name="T">��������</typeparam>
public class Singleton<T> where T : new() 
{ 
    private static T _instance ;
    static Singleton()
    {
        _instance = new T();
    }
    public static T Instance
    {
        get { return _instance; }
    }
}


/// <summary>
/// ���˵���
/// </summary>
public class Singleton
{
    private Singleton() { }
    public static readonly Singleton Instance = new Singleton();    
}
