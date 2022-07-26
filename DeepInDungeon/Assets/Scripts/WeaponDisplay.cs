using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public Text nameText;
    public Text atkText;
    public Text defText;

    public List<GameObject> slots = new List<GameObject>();

    public Text discriptiontText;

    public Image Image;

    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        HideSlots();
        ShowWeapon();
    }
   
    public void ShowWeapon()
    {


        nameText.text = weapon.name;
        atkText.text = weapon.Attack.ToString();
        defText.text = weapon.Defense.ToString();
        discriptiontText.text = weapon.weaponDescribtion;
        for (int i = 0; i < weapon.slotNumber; i++)
        {
            slots[i].SetActive(true);
        }
     
    }

    public void HideSlots()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }

    }
}
