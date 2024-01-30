using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : BaseSkill
{
    public override void Activate()
    {
        base.Activate();
        /*Enemy[] enemy = GetComponent<Enemy>();
        foreach(var en in enemy)
        {
            Destroy(en);
        }*/
    }
}
