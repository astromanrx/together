using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Base behaviour for objects
/// </summary>
public class BB: MonoBehaviour{
    private void Start (){
        OnStart();
    }

    private void Update(){
        if(Application.isPlaying){
            OnUpdate();
        }
    }

    private void OnDestroy(){
        if(this is IDisposable){
            (this as IDisposable).Dispose();
        }
    }

    private void Spawn<T>(T component,Vector3 position) where T : Component {
        var gameObject = Instantiate(component, position, Quaternion.identity);
        gameObject.AddComponent<T>();
    }

    protected virtual void OnStart(){}

    protected virtual void OnUpdate(){}
}