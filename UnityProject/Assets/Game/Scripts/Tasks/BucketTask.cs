using UnityEngine;

public class BucketTask : Task{
    private Vector3 actionPosition;

    public BucketTask(Vector3 actionPosition)
    {
        this.actionPosition = actionPosition;
    }

    public override void OnEnter()
    {
        mCharacter.CharacterController.MoveTo(actionPosition);
        mCharacter.AnimationController.Play(IsoAnimationController.Animation.Melee);
    }
    public override bool OnUpdate()
    {
        return true;
    }
}