using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponDropZone : DropZone, IDropHandler
{
    public Weapon.Hand hand = Weapon.Hand.Empty;//由外部管理器決定此物件是哪隻手的區域

    public WeaponDeckManager wdManager;

    public Weapon weaponOn { get; set; }

    public void OnDrop(PointerEventData eventData)
    {
        if (hand == Weapon.Hand.Empty || hand == Weapon.Hand.TwoHanded)
        {
            Debug.LogError("此手牌區找不到歸屬");
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
           
           

            if (CheckHas<WeaponDisplay>())//如果上面有武器先返回
            {
                Debug.Log("上面有武器了");
                RemoveWeaponOn();
            }


            DropIn(dropInStuff);

            TellManagerANewWeapon(dropInStuff.GetComponent<WeaponDisplay>().weapon);
            
        }
        
    }

    public void RemoveWeaponOn()
    { 
        Weapon prepareRemoveWeapon = WeaponOnZone();
        ReturnAllObjectToOrigin();
        //告訴要把moves移除
        wdManager.TellMDMDestroyMoves(prepareRemoveWeapon);
    }

    private bool CheckHand(WeaponDisplay wd)
    {
        if (wd.weapon.WeaponHand == Weapon.Hand.TwoHanded)
        {//當進來的是雙手武器只能擺在主武器的位置
            if ( hand == Weapon.Hand.Main)
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
        Weapon we = null;
        foreach (Transform child in this.transform)
        {
            
            if (child.gameObject.GetComponent<WeaponDisplay>()!=null)
            {
                we = child.gameObject.GetComponent<WeaponDisplay>().weapon;
                
            }
            Debug.Log(child.gameObject.GetComponent<WeaponDisplay>().weapon.name);
        }

        if (we == null)
        {
            Debug.LogError(hand.ToString()+"上面沒有武器");
        }
        return we;

    }

    /// <summary>
    /// 告訴控制器傳入這個Dropzone的weapon
    /// </summary>
    private void TellManagerANewWeapon(Weapon weapon)
    {
        if (hand == Weapon.Hand.Main)
        {
            wdManager.MainWeapon = weapon;
        }
        else if (hand == Weapon.Hand.Secondary)
        {
            wdManager.SecondaryWeapon = weapon;
        }
    }


}
