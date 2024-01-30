using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 3f;
    public float AttackDamage = 1f;
    bool bIsDead = false;
    public bool bMustSpawnItem = false;
    public float MoveSpeed;
    public GameObject ExplodeFx;

    private void Start()
    {

    }

    private void Update()
    {
        
    }
    public void OnDestroy()
    {
        if (!bIsDead)
        {
            GameManager.Instance.EnemyDies();
        }
    }

    IEnumerator freeze()
    {
        yield return WaitForSecondsRealtime(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health -= 1;
        }
    }

    IEnumerator HitFlick()
    {
        yield return null;
    }
}
