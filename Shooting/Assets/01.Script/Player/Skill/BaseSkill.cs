using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    protected PlayerCharater _playerCharater;
    public float CooldownTime;
    public float CurrentTime;
    public bool bIsCoolDown = false;
    // Start is called before the first frame update

    public void Init(PlayerCharater playerCharater)
    {

    }
    public void Update()
    {
        if (bIsCoolDown)
        {
            CurrentTime -= Time.deltaTime;
            if(CurrentTime < 0)
            {
                CurrentTime = CooldownTime;
                bIsCoolDown = false;
            }
        }    
    }

    public bool IsAvailable()
    {
        return bIsCoolDown=true;
    }

    public virtual void Activate()
    {
        IsAvailable();
    }

    public void InitCoolDown()
    {

    }
}
