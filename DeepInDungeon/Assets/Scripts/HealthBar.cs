using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;



    //更改血條顯示
    public void ShowHealthBar(HpStatus hpStatus)
    {
        slider.maxValue = hpStatus.hpMax;
        slider.value = hpStatus.hp;

        string max = hpStatus.hpMax.ToString();
        string current = hpStatus.hp.ToString();
        healthText.text = current + "/" + max;
    }
}
