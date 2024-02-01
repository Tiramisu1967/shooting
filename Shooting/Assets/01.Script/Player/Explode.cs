using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        Destroy(this.gameObject, 1f);
    }
}
