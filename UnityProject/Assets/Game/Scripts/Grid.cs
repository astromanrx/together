using System;
using System.Collections.Generic;
using UnityEngine;

public class Grid <T> where T : class
{
    private Dictionary<Vector3Int,T> mObjects;

    public Grid(){
        mObjects = new Dictionary<Vector3Int, T>();
    }

    
    public T this[Vector3Int position] {
        get{
            if (mObjects.ContainsKey(position)){
                return mObjects[position];
            }
            return null;
        }
    }  
    public T this[Vector2Int position] {
        get{
            
            if (mObjects.ContainsKey((Vector3Int)position)){
                return mObjects[(Vector3Int)position];
            }
            return null;
        }
    }

    public void InsertAt(Vector2Int position, T obj)
    {
        mObjects.Add((Vector3Int)position,obj);
    }

    public void InsertAt(Vector3Int position, T obj)
    {
        mObjects.Add(position,obj);
    }

    public void RemoveAt(Vector3Int position){
        mObjects.Remove(position);
    }

    public void Remove(IsoObject obj)
    {
        List<Vector3Int> keys = new List<Vector3Int>();
        foreach(var pair in mObjects){
            if(pair.Value.Equals(obj)){
                keys.Add(pair.Key);
            }
        }

        foreach(var key in keys){
            mObjects.Remove(key);
        }
    }
}