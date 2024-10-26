public class IsoCharacter : BB
{
    public  IsoCharacterController CharacterController{get;private set;}
    public IsoAnimationController AnimationController{get;private set;}
    protected override void OnStart()
    {
        CharacterController = GetComponent<IsoCharacterController>();
        AnimationController = GetComponent<IsoAnimationController>();
    }
}
