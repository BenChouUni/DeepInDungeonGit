using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponDropZone : DropZone, IDropHandler
{
    public Hand hand = Hand.Empty;//由外部管理器決定此物件是哪個

    public WeaponDeckManager wdManager;

    public Weapon weaponOn { get; set; }

    public void OnDrop(PointerEventData eventData)
    {
        if (hand == Hand.Empty || hand == Hand.TwoHanded)
        {
            Debug.Log("這空間未被認為是哪種手");
            return;
        }

        GameObject dropInStuff = eventData.pointerDrag;

        if (dropInStuff.GetComponent<WeaponDisplay>()!=null)//確定進來的是武器
        {
            if (CheckHand(dropInStuff.GetComponent<WeaponDisplay>()) == false)
            {
                Debug.Log("似乎放錯手了");
                return;
            }
           
           

            if (CheckHas<WeaponDisplay>())//確定原先上面有沒有武器
            {
                Debug.Log("上面有武器了");
                ReturnAllObjectToOrigin();
            }

            DropIn(dropInStuff);
            TellWeaponType();
            
        }
        
    }

    private bool CheckHand(WeaponDisplay wd)
    {
        if (wd.weapon.WeaponHand == Hand.TwoHanded)
        {//當進來的是雙手武器只能擺在主武器的位置
            if ( hand == Hand.Main)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        return wd.weapon.WeaponHand == hand;
    }

    public Weapon WeaponOnZone()
    {
        Weapon we = ZoneList[0].GetComponent<WeaponDisplay>().weapon;

        return we;

    }

    /// <summary>
    /// 告訴控制器傳入這個Dropzone的weapon
    /// </summary>
    private void TellWeaponType()
    {
        if (hand == Hand.Main)
        {
            
           
            wdManager.MainWeapon = WeaponOnZone();
        }
        else if (hand == Hand.Secondary)
        {
            wdManager.SecondaryWeapon = WeaponOnZone();
        }
    }
}
