using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewAttack",menuName ="CreateMoveAction/Attack")]
public class AttackAction : MoveAction
{
    
    public int dmg;

    public override void Action()
    {
        
        Debug.Log(string.Format("override成功，執行攻擊造成{0}傷害",dmg));
    }
}
