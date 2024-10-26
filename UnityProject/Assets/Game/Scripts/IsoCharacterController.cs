using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using AStar;

public class IsoCharacterController : BB
{
    [SerializeField]
    private Tilemap mTilemap;

    [SerializeField]
    private float mMovementSpeed;
    private bool mReachedToTarget = true;
    private Vector2 mTarget;
    

    protected override void OnStart()
    {
        mTilemap  = BehaviourLocator.Instance.Get<Tilemap>();
        // MoveTo(new Vector2(5,5));
    }

    protected override void OnUpdate()
    {
        StepMovement();
    }    

    public void MoveTo(Vector3 worldPoint){
        mReachedToTarget = false;
        
        // var worldPoint = Camera.main.ScreenToWorldPoint(target);
        var cell = mTilemap.WorldToCell(worldPoint);
        var tile = mTilemap.GetTile(cell);
        mTarget = mTilemap.GetCellCenterWorld(cell);
    }

    private void StepMovement(){
        if(!mReachedToTarget){
            var delta = mTarget - (Vector2)transform.position;
            transform.position += (Vector3)(delta.normalized * mMovementSpeed * Time.deltaTime);
            var newDelta = mTarget - (Vector2)transform.position;
            if(Mathf.Sign(newDelta.x) != Mathf.Sign(delta.x) || Mathf.Sign(newDelta.y) != Mathf.Sign(delta.y) ){
                //Reached to target
                // transform.position = mTarget;
                mReachedToTarget = true;
            }
            this.GetComponent<IsoAnimationController>().Speed = 1.0f;
        }else{
            this.GetComponent<IsoAnimationController>().Speed = 0;
        }
    }
}
