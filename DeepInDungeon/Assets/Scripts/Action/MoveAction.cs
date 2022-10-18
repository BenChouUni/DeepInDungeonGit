using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveAction:ScriptableObject,IAction
{
    public string name;
    public string description;

    public virtual void Action()
    {
        
    }
}
