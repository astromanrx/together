public class IdleTask : Task{
    public override void OnEnter()
    {
        mCharacter.AnimationController.Play(IsoAnimationController.Animation.Idle);
    }
}