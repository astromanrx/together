using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldObjectsRepository
{
    private static WorldObjectsRepository mInstance;
    public static WorldObjectsRepository Instance{
        get { 
            if (mInstance == null){
                mInstance = new WorldObjectsRepository();
            }
            return mInstance; 
        }
    }

    private Grid<IsoObject> mDeckObjects;
    private Tilemap mTilemap;

    public WorldObjectsRepository(){
        mDeckObjects = new Grid<IsoObject>();
        mTilemap = BehaviourLocator.Instance.Get<Tilemap>(); 
    }
    
    public IsoObject GetIsoAt(int x, int y)
    {
        return mDeckObjects[new Vector2Int(x,y)];
    }

    public Vector3Int AddIsoObject(IsoObject obj){
        var cell = mTilemap.WorldToCell(obj.transform.position);
        mDeckObjects.InsertAt(cell, obj) ;
        return cell;
    }

    public void RemoveIsoObject(IsoObject obj){
        mDeckObjects.Remove(obj) ;
    }
}