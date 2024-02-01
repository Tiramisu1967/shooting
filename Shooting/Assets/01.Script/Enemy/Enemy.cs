using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 3f;
    public float AttackDamage = 1f;
    bool bIsDead = false;
    public bool bIsFreeze = false;
    public bool bIsDestroy = false;
    public bool bMustSpawnItem = false;
    public float MoveSpeed;
    public float freezetime;
    private float tmpSpeed;
    public GameObject ExplodeFX;

    void Start()
    {
        freezetime = 3;
        tmpSpeed = MoveSpeed;
    }

    void Update()
    {
        if (bIsFreeze)
        {
            MoveSpeed = 0;
            if (freezetime <= 0)
            {
                freezetime -= Time.deltaTime;
                Debug.Log(freezetime);
            }
            else
            {
                freezetime = 3;
                bIsFreeze = false;
            }
            MoveSpeed = tmpSpeed;
        }
    }
    public void Dead()
    {
        if (!bIsDead)
        {
            GameManager.Instance.EnemyDies();

            if (!bMustSpawnItem)
                GameManager.Instance.ItemManager.SpawnRandomItem(0, 3, transform.position);
            else
                GameManager.Instance.ItemManager.SpawnRandomItem(transform.position);

            bIsDead = true;

            Instantiate(ExplodeFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health -= 1;
            if (Health < 0)
            {
                if (Health <= 0f)
                {
                    Dead();
                }

                StartCoroutine(HitFlick());
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator HitFlick()
    {
        int flickCount = 0; // ������ Ƚ���� ����ϴ� ����

        while (flickCount < 1) // 1�� ������ ������ �ݺ�
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);

            yield return new WaitForSeconds(0.1f); // 0.1�� ���

            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            yield return new WaitForSeconds(0.1f); // 0.1�� ���

            flickCount++; // ������ Ƚ�� ����
        }
    }
}