using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsRegisterar : Registerar
{
    public override void Register()
    {        
        var actions = SceneHelper.findComponentsInNodeHirearchy<UIAction>(transform);
        UIActionManager.Instance.RegisterActions(actions);
    }
    
}
