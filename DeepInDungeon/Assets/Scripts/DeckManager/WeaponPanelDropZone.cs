using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponPanelDropZone : DropZone,IDropHandler
{
    public WeaponDeckManager WDManager;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropInStuff = eventData.pointerDrag;
        if (dropInStuff.GetComponent<WeaponDisplay>()!=null)
        {
            Weapon dropInWeapon = dropInStuff.GetComponent<WeaponDisplay>().weapon;
            DropIn(dropInStuff);
            WDManager.TellMDMDestroyMoves(dropInWeapon);
            WDManager.RemoveWeaponOnHand(dropInWeapon);
        }
        
    }


}
