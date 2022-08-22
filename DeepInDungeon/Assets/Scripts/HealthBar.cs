using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    public void SetMaxHealth(int maxHp)
    {
        slider.maxValue = maxHp;
        slider.value = maxHp;

    }

    public void SetHealth(int hp)
    {
        slider.value = hp;
    }

    public void SetText(int _hp, int _maxhp)
    {
        string max = _maxhp.ToString();
        string current = _hp.ToString();
        healthText.text = current + "/" + max;

    }
}
