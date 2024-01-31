using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [HideInInspector]
    public float MoveSpeed = 2f;
    
    private Vector3 _direction;
    
    public GameObject ExplodeFX;
    
    [SerializeField]
    private float _lifeTime = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

}
