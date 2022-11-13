using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyObject", menuName = "CreateMyObject/MoveList")]
public class MovesList : ScriptableObject
{
    public List<Moves> list;

}
