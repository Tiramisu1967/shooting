using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    static public GameManager Instance;

    public PlayerCharater _player;
    public PlayerCharater Player => _player;

    public MapManager MapManager;
    public MapManager ItemManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        MapManager.Init(this);
        ItemManager.Init(this);
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void EnemyDies()
    {
        AddScore(10);
    }

    IEnumerator LoadNextStageAfterDelay(float deley)
    {
        yield return new WaitForSeconds(deley);

        switch (GameInstance.instance.CurrentStageLevel)
        {
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
        }
    }
    public void AddScore(int score)
    {

    }
}
