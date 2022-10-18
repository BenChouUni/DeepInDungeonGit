using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAction : MoveAction
{
    public int def;

    public override void Action()
    {
        Debug.Log(string.Format("使用防禦{0}",def));
    }
}
