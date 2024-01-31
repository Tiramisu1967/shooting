using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeaponItem : BaseItem
{
    public override void OnGetItem(PlayerCharater playerCharater)
    {

        if(playerCharater.CurrentWeaponLevel < playerCharater.MaxWeaponLevel)
        {
        playerCharater.CurrentWeaponLevel += 1;
        GameInstance.instance.CurrentPlayerWeaponLevel = playerCharater.CurrentWeaponLevel;
        }
    }
}
