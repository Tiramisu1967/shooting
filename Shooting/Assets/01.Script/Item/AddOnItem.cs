using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AddOnItem : BaseItem
{


    public GameObject Prefab;
    public override void OnGetItem(PlayerCharater playerCharater)
    {

        base.OnGetItem(playerCharater);


        if (GameInstance.instance.CurrentPlayerAddOnCount < 2)
        {
            SpawnAddOn(GameManager.Instance.Player.GetComponent<PlayerCharater>().transform.position, Prefab,GameManager.Instance.Player.GetComponent<PlayerCharater>().AddOnTransform[GameInstance.instance.CurrentPlayerAddOnCount].transform);;
            GameInstance.instance.CurrentPlayerAddOnCount += 1;
        }
        else
        {
            Destroy(this);
        }

    }


    public static void SpawnAddOn(Vector3 pos, GameObject Add, Transform transform)
    {
        GameObject instance = Instantiate(Add, pos, Quaternion.identity);
        instance.GetComponent<AddOn>().PlayerPos = transform;


    }
}
