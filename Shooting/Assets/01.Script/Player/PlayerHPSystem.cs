using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerHPSystem : MonoBehaviour
{
    public int Health;
    public int MaxHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        Health = GameInstance.instance.CurrentPlayerHP;
    }
    public void InitHealth()
    {
        Health = MaxHealth;
        GameInstance.instance.CurrentPlayerHP = Health;
    }

    IEnumerator HitFlick()
    {
        int Flick = 0;
        while (Flick < 5)
        {
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            yield return new WaitForSeconds(0.1f);
            Flick++;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
            &&!GameManager.Instance.Player.Invincibility)
        {
            Health -= 1;
            GameInstance.instance.CurrentPlayerHP = Health;
            Destroy(collision.gameObject);

            if(Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            BaseItem item = collision.gameObject.GetComponent<BaseItem>();
            item.OnGetItem(GameManager.Instance.Player);
        }
        GameInstance.instance.CurrentPlayerHP = Health;
    }
}
