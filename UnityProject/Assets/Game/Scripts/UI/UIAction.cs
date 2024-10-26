using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAction : BB, IPointerClickHandler
{
    [SerializeField]
    private string mName;

    // Hides parent name to prevent Name property confusion 
    public new string name => mName;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    protected override void OnStart()
    {
        
    }

    protected virtual void OnClick(){
        UIActionManager.Instance.ExecuteAction(this);
        Hide();
    }

    protected void Hide(){
        UIActionManager.Instance.HideAction();
    }
}
