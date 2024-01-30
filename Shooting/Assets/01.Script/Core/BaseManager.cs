using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class BaseManager : MonoBehaviour
{

    public GameManager _gameManager;

    public GameManager GameManager { get { return _gameManager; } }

    public virtual void Init(GameManager gameManger)
    {
        _gameManager = gameManger;
    }
}
