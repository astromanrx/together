using UnityEngine;

public abstract class Registerar: MonoBehaviour{
    private void Awake(){
        Register();
    }

    public abstract void Register();
}