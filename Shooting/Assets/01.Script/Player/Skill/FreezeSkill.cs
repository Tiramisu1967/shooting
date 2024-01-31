using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSkill :BaseSkill
{
    public override void Activate()
    {
        base.Activate();
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var en in enemy)
        {
            if(en != null)
            {
                
            }
        }
    }
}
