
using UnityEngine;

public class TaskRunner: BB{
    private Task mCurrentTask;
    private IsoCharacter mCharacter;

    protected override void OnStart()
    {
        mCharacter = GetComponent<IsoCharacter>();
        mCurrentTask = Task.Idle;
    }

    protected override void OnUpdate()
    {
        Debug.Log(mCurrentTask);
        
        if(! mCurrentTask.OnUpdate()){
            mCurrentTask.OnExit();
            mCurrentTask = Task.Idle;
            mCurrentTask.OnEnter();
        }

        if(mCurrentTask == Task.Idle){
            if(TaskRepository.Instance.TryTake(out Task newTask)){
                newTask.AssignTo(mCharacter);
                mCurrentTask.OnExit();
                mCurrentTask = newTask;
                mCurrentTask.OnEnter();
            }
        }

    }
}