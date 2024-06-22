
/// <summary>
/// 泛型单例,用Instance获取
/// </summary>
/// <typeparam name="T">单例类型</typeparam>
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
/// 懒人单例
/// </summary>
public class Singleton
{
    private Singleton() { }
    public static readonly Singleton Instance = new Singleton();    
}
