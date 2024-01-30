using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSkill : BaseSkill
{
    public override void Activate()
    {
        base.Activate();
        if (GameInstance.instance.CurrentPlayerHP == 3)
        {
            if (GameInstance.instance.CurrentPlayerFuel <= 20)
            {
                GameInstance.instance.CurrentPlayerFuel -= 20;
                GameInstance.instance.CurrentPlayerHP += 1;
            }
        }
    }
}
