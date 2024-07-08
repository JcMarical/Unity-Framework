

//服务器的角色
public class RoleServer
{
    static int  currentThisId = 0;
    public static  int GetNewThisID()
    {
        return currentThisId++;
    }
    
}
