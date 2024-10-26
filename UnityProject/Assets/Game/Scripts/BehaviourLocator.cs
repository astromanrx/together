using System;
using System.Collections.Concurrent;

public class BehaviourLocator : IServiceLocator
{
    private static IServiceLocator mInstance;
    public static IServiceLocator Instance{
        get{
            if(mInstance == null){
                mInstance = new BehaviourLocator();
            }
            return mInstance;
        }
    }

    private ConcurrentDictionary<Type,object> mBehaviors = new ConcurrentDictionary<Type, object>();
    public T Get<T>()
    {
        if(mBehaviors.TryGetValue(typeof(T), out var service)){
            return (T)service;
        }
        throw new NullReferenceException($"Service {typeof(T).Name} not found");
    }

    public object Get(Type type)
    {
        if(mBehaviors.TryGetValue(type, out var service)){
            return service;
        }
        throw new NullReferenceException($"Service {type.Name} not found");
    }

    public bool IsRegistered<T>()
    {
        return mBehaviors.ContainsKey(typeof(T));
    }

    public bool IsRegistered(Type type)
    {
        return mBehaviors.ContainsKey(type);
    }

    public void Register<T>(T service)
    {
        mBehaviors.TryAdd(typeof(T),service);
    }

    public void Register(Type type, object service)
    {
        mBehaviors.TryAdd(type,service);
    }

    public bool Unregister<T>()
    {
        return mBehaviors.TryRemove(typeof(T), out var _);
    }

    public bool Unregister(Type type)
    {
        return mBehaviors.TryRemove(type, out var _);
    }
}