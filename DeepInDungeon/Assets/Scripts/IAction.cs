using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有行為只做用於玩家或敵人上，並需要武器的資訊（未來可能需要）
/// </summary>
interface IAction
{
    void Action();

}
