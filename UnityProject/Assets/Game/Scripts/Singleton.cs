using System;

public class Singleton<T> where T : class
{
    private static T instance = null;
    protected Singleton()
    {
    }

    public static T Instance
    {
        get
        {
            
            if (instance == null)
            {
                instance = Activator.CreateInstance<T>();
            }
            return instance;        
        }
    }
}