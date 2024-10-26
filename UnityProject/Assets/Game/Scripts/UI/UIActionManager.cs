using System;
using System.Collections.Generic;
using UnityEngine;

public class UIActionManager : Singleton<UIActionManager>
{
    private Dictionary<string,UIAction> mActions;
    private UIAction mCurrentAction;

    public event Action<string,Vector3> OnActionEvent;

    public UIActionManager(){
        mActions = new Dictionary<string, UIAction>();
    }

    public void RegisterActions(UIAction[] actions)
    {
        foreach(UIAction action in actions){
            Debug.Log($"Action {action.name} registered!");
            mActions.Add(action.name.ToLowerInvariant(),action);
        }        
    }

    public void ShowAction(string actionName, Vector3 position)
    {
        if(mActions.TryGetValue(actionName.ToLowerInvariant(), out var action)){
            action.transform.position = position;
            action.gameObject.SetActive(true);
            mCurrentAction = action;
        }else{
            throw new Exception($"Action {actionName} not found.");
        }
    }

    public void HideAction()
    {
        if(mCurrentAction != null){
            mCurrentAction.gameObject.SetActive(false);
        }
        
    }

    public void ExecuteAction(UIAction action)
    {
        OnActionEvent?.Invoke(action.name, action.transform.position);
    }
}