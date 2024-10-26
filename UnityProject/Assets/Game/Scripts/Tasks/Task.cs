using System;

public class Task{
    public static readonly Task Idle = new IdleTask();

    protected IsoCharacter mCharacter{ get; private set; }
    public float Progress{get; private set;}
    
    public virtual bool IsTickable(){
        return false;
    }

    public virtual void OnEnter(){}
    public virtual bool OnUpdate(){
        return false;
    }
    public virtual void OnExit(){}

    public void AssignTo(IsoCharacter character)
    {
        mCharacter = character;
    }
}