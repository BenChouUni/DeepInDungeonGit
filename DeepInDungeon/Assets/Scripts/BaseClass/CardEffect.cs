using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardEffect : MonoBehaviour
{
    [TextArea(2, 5)]
    public string effectText;
    public bool targetsActiveCharacter;

    public virtual void ApplyEffect()
    {
    }

    public virtual string CardDescription()
    {
        return "";
    }
}
