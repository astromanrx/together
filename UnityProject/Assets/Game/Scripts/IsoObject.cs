using UnityEngine;
using UnityEngine.Tilemaps;

public class IsoObject: BB{
    [SerializeField]
    private bool IsTickable;

    protected override void OnStart()
    {
        WorldObjectsRepository.Instance.AddIsoObject(this);
    }

    protected override void OnUpdate(){
        if(IsTickable){
            WorldObjectsRepository.Instance.RemoveIsoObject(this);
            WorldObjectsRepository.Instance.AddIsoObject(this);
        }
    }
}