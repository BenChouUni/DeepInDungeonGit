using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public Image bg;
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

        BgColorChange(weapon.WeaponHand);
        for (int i = 0; i < weapon.slotNumber; i++)
        {
            slots[i].SetActive(true);
        }
     
    }

    private void BgColorChange(Hand hand)
    {
        switch (hand)
        {
            case Hand.Empty:
                //不在手上淺藍色
                bg.color = new Color32(141, 200, 219,255);
                return;
            case Hand.Main:
                //主手紅色
                bg.color = new Color32(219, 50, 50,255);
                return;
            case Hand.Secondary:
                //副手藍色
                bg.color = new Color32(50, 74, 220,255);
                return;
            case Hand.TwoHanded:
                //雙手紫色
                bg.color = new Color32(148, 73, 229,255);
                return;
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
