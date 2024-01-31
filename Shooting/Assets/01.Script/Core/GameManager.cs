using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    static public GameManager Instance;
    public bool bStageCleared = false;
    public PlayerCharater _player;
    public PlayerCharater Player => _player;

    public MapManager MapManager;
    public ItemManager ItemManager;
    public EnemySpawner EnemySpawner;

    public Canvas StageRecultCanvas;
    public TMP_Text CurrentScoreText;
    public TMP_Text TimeText;

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
        EnemySpawner.Init(this);
        
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
