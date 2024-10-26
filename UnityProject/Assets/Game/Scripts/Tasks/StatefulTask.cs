
public class StatefulTask : Task{
    public class State{
        public static State ExitState = new State();
        public StatefulTask StateMachine{get;set;}

        public virtual void OnEnter(){}
        public virtual void OnExit(){}
        public virtual bool OnUpdate(){ return false;}
    }

    private State mCurrentState;
    private bool mRunning;

    public StatefulTask(State initialState){
        mCurrentState = initialState;
        mRunning = true;
        InitiateState(mCurrentState);
    }

    private void InitiateState(State state){
        state.StateMachine = this;
        state.OnEnter();
    }

    public void ChangeState(State newState){
        mCurrentState.OnExit();
        mCurrentState = newState;
        if(newState == State.ExitState){
            Exit();
            return;
        }
        InitiateState(mCurrentState);
    }

    private void Exit(){        
        mRunning = false;
    }

    public override void OnEnter()
    {
        mCurrentState.OnEnter();
    }

    public override void OnExit()
    {
        mCurrentState.OnExit();
    }

    public override bool OnUpdate()
    {
        mCurrentState.OnUpdate();
        return mRunning;
    }

    public override bool IsTickable()
    {
        return true;
    }
}