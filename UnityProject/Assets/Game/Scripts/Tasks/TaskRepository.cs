using System;
using Helper.Collections;

public class TaskRepository : Singleton<TaskRepository>
{
    private readonly PriorityQueue<Task,TaskPriority> mTasks;
    public TaskRepository(){
        mTasks = new PriorityQueue<Task,TaskPriority>();
    }

    public bool TryTake(out Task task)
    {
        return mTasks.TryDequeue(out task,out _);
    }

    public void PushTask(Task task, TaskPriority priority){
        mTasks.Enqueue(task,priority);
    }
}