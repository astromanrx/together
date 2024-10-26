using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPlacement{
    private Tilemap mTilemap;
    private MonoBehaviour mSelectedObject;
    
    public void Initialize(Tilemap tilemap){
        mTilemap = tilemap;
    }

    private void UpdatePosition(Vector3 worldPoint){        
        if(mSelectedObject != null){
            var cell = mTilemap.WorldToCell(worldPoint);
            mSelectedObject.transform.position = mTilemap.GetCellCenterWorld(cell);
        }     
    }

    public void SelectAt(Vector3 worldPoint){
        var cell = mTilemap.WorldToCell(worldPoint);
        mSelectedObject = WorldObjectsRepository.Instance.GetIsoAt(cell.x,cell.y);
    }
}