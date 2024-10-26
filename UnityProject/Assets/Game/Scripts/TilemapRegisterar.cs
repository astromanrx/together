using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapRegisterar : Registerar
{
    public override void Register()
    {
        BehaviourLocator.Instance.Register(GetComponent<Tilemap>()); 
    }
}
