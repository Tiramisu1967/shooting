using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossA : MonoBehaviour
{
    public GameObject Projectile;
    public float ProjectileMoveSpeed = 5.0f;
    public float FireRate = 2.0f;
    public float MoveSpeed = 2.0f;
    public float MoveDistance = 5.0f;

    private int _currentPatternIndex = 0;
    private bool _movingRight = true;
    private bool _bCanMove = false;
    private Vector3 _originPosition;

    
    // Start is called before the first frame update
    void Start()
    {
            _originPosition = transform.position;
    }

    private IEnumerator MoveDownAndStartPattern()
    {
        yield return new WaitForSeconds(2f);
        Nextpattern();
    }
    void Update()
    {
        if(_bCanMove)
        {
            MoveSideways();
        }
    }

    private void Nextpattern()
    {
        _currentPatternIndex = Random.Range(0, 2);
        switch(_currentPatternIndex)
        {
            case 0:
                pattern1();
                break;
            case 1:
                pattern2();
                break;
            case 2:
                Pattern3();
                break;
        }

    }

    private void MoveSideways()
    {
        if (_movingRight)
        {
            transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0));
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x < 0) pos.x = 0;
            transform.position = Camera.main.ViewportToWorldPoint(pos);

        }
        else
        {
            transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0));
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x > 1) pos.x = 1;
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }

    public void ShootProjectile(Vector3 position, Vector3 direction)
    {
        GameObject instance = Instantiate(Projectile, position, Quaternion.identity);
        Projectile projectile = instance.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.MoveSpeed = ProjectileMoveSpeed;
            projectile.SetDirection(direction.normalized);
        }
    }

    private void pattern1()
    {
            Vector3 position = GameManager.Instance.Player.transform.position;
            for (int i = 0; i < 370; i += 10)
            {
                float angle = i * Mathf.Deg2Rad;
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                ShootProjectile(position, direction);
            }
            MoveDownAndStartPattern();

    }

    IEnumerator pattern2()
    {
        Vector3 position = GameManager.Instance.Player.transform.position;
        for (int n = 0; n < 5; n++)
        {
            for (int i = 0; i < 370; i += 10)
            {
                float angle = i * Mathf.Deg2Rad;
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                ShootProjectile(position, direction);
            }
            yield return new WaitForSeconds(1f);
        }
        MoveDownAndStartPattern();
    }

    public void Pattern3()
    {
        if(this.GetComponent<Enemy>().Health == 1)
        {
            this.GetComponent<Enemy>().Health += 1;
            MoveDownAndStartPattern();
        }
        else
        {
            Nextpattern();
        }
    }

    // Update is called once per frame

}
