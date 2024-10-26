using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneHelper{
    public static void traverse(Transform node , Action<Transform> action){
        for(int childIndx = 0;childIndx < node.childCount;childIndx++){
            var childNode = node.GetChild(childIndx);
            action(childNode);
            traverse(childNode,action);               
        }
    }

    public static T[] findComponentsInNodeHirearchy<T>(Transform transform){
        List<T> components = new List<T>();
        traverse(transform,(node)=>{
            var component = node.GetComponent<T>();
            if(component != null){
                components.Add(component);
            } 
        });
        return components.ToArray();
    }
}