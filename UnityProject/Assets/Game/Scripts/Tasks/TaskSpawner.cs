using System;
using UnityEngine;

public class TaskSpawner: BB{
    [SerializeField]
    private GameObject mBucketTask;

    protected override void OnStart()
    {
        UIActionManager.Instance.OnActionEvent += OnActionEvent;
    }

    private void OnActionEvent(string actionName,Vector3 actionPosition)
    {
        switch(actionName.ToLowerInvariant()){
            case "bucket":
            var task = new BucketTask(actionPosition);
            TaskRepository.Instance.PushTask(task,TaskPriority.Normal);
            Instantiate(mBucketTask,actionPosition,Quaternion.identity,transform);            
            break;
        }
        
    }
}