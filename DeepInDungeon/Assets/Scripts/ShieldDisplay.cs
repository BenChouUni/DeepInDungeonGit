using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public Text shieldText;

    public void SetShield(int shield)
    {
        shieldText.text = shield.ToString();
    }
}
