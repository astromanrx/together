using System.Collections;
using System.Collections.Generic;
using Tiles;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class InputsController : BB
{
    public InputActionReference mSelectAction;
    public InputActionReference mMoveAction;

    private Tilemap mTilemap;

    protected override void OnStart()
    {
        mTilemap = BehaviourLocator.Instance.Get<Tilemap>();

        mSelectAction.action.Enable();
        mMoveAction.action.Enable();

        mSelectAction.action.performed += (InputAction.CallbackContext context)=>{
            var mousePosition = mMoveAction.action.ReadValue<Vector2>();
            if(TryPickObject(mousePosition, out var pickedObject)){
                if(pickedObject is Water){
                    UIActionManager.Instance.ShowAction(actionName: "Bucket", pickedObject.transform.position);
                }
            }
        };

        mMoveAction.action.performed += (InputAction.CallbackContext context)=>{
            // Debug.Log(context.ReadValue<Vector2>());
        };
    }

    private bool TryPickObject(Vector3 mousePosition, out IsoObject obj){
        var worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        var cell = mTilemap.WorldToCell(worldPoint);
        obj = WorldObjectsRepository.Instance.GetIsoAt(cell.x,cell.y);
        if(obj == null) {
            return false;
        }
        return true;
    }
}
