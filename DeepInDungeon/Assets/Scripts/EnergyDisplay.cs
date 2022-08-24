using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyDisplay : MonoBehaviour
{
    public Text energyText;
    private int maxEnergy;

    public void SetMaxEnergy(int _maxEnergy)
    {
        maxEnergy = _maxEnergy;
        string max = maxEnergy.ToString();
        energyText.text = max + "/" + max;
    }

    public void SetEnergy(int energy)
    {
        string current = energy.ToString();
        string max = maxEnergy.ToString();
        energyText.text = current + "/" + max;
    }
}
