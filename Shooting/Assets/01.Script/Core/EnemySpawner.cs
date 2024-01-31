using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : BaseManager
{
    public GameObject[] Enemy;
    public GameObject Meteor;
    public GameObject BossA;
    public Transform[] EnemySpawnTransform;
    public float CoolDownTime;
    private int[] bin;
    public int MaxSpawn;
    public int BossSpawnCount;
    private int _spawnCount;
    private bool _bSpawnBoss;

    public override void Init(GameManager gameManger)
    {
        base.Init(gameManger);
        StartCoroutine(SpawnEnemy());
        Debug.Log("�̰� ����ü �� ��?, �̰� ����Ǵ´µ� �� ������ �ȵ�? �� �ȵ�?");
    }



    IEnumerator SpawnEnemy()
    {
        while (!_bSpawnBoss)
        {
            Debug.Log("�̰� ����ü �� ��?, �̰� ����Ǵ´µ� �� ������ �ȵ�? �� �ȵ�?.");
            yield return new WaitForSeconds(CoolDownTime);
            List<int> position = new List<int>(EnemySpawnTransform.Length);

            for(int i = 0; i < EnemySpawnTransform.Length; i++)
            {
                Debug.Log("�̰� ����ü �� ��?, �̰� ����Ǵ´µ� �� ������ �ȵ�? �� �ȵ�?????");
                position.Add(i);
            }

                Debug.Log("�̰� ����ü �� ��?, �̰� ����Ǵ´µ� �� ������ �ȵ�? �� �ȵ�???????????");
            for(int i = 0; i < MaxSpawn; i++)
            {
                int randomEnemy = Random.Range(0, Enemy.Length);
                int index = Random.Range(0, position.Count - 1);
                int randomPosition = position[index];
                
                position.RemoveAt(index);
                Instantiate(Enemy[randomEnemy], EnemySpawnTransform[randomPosition].position, Quaternion.identity);
            }
            _spawnCount++;
            if(_spawnCount == BossSpawnCount)
            {
                _bSpawnBoss = true;
            }
        }
        if (_bSpawnBoss)
        {
            Instantiate(BossA, EnemySpawnTransform[Random.Range(0, EnemySpawnTransform.Length)].position, Quaternion.identity);
        }

    }
}
