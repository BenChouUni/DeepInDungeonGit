using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    private HpStatus hpStatus;
    

    public void SetMaxHealth(int maxHp)
    {
        hpStatus = new HpStatus(maxHp);
        slider.maxValue = maxHp;
        slider.value = maxHp;
        SetText();
        
    }

    public void SetHealth(int hp)
    {
        hpStatus.hp = hp;
        slider.value = hp;
        SetText();
    }

    public void SetText()
    {
        string max = hpStatus.hpMax.ToString();
        string current = hpStatus.hp.ToString();
        healthText.text = current + "/" + max;

    }
}
