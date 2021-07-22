using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public Wave[] Waves;
    public Transform SpawnPoint;
    private List<Enemy> enemies = new List<Enemy>();
    private Wave currentWave;
    private int nextWaveIndex = 0;
    private float timer = 0;
    private float timeDelay = 0;
    private int counter = 0;
    private bool isLastWave = false;

    public event UnityAction<Enemy> EnemySpawned;
    public event UnityAction WavesEnded;
    // Start is called before the first frame update
    void Start()
    {
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLastWave)
        {
            return;
        }

        timer += Time.deltaTime;
        timeDelay += Time.deltaTime;

        if(timeDelay >= currentWave.Delay)
        {
            if(counter < currentWave.Capacity)
            {
                if(timer >= currentWave.TimeBetweenSpawn)
                {
                    Spawn(currentWave.EnemyPrefab, SpawnPoint.position);
                    counter++;
                    timer = 0;
                }
            }
            else
            {
                if(!TrySetLastWave())
                {
                    NextWave();
                    counter = 0;
                    timer = 0;
                    timeDelay = 0;
                }
                else
                {
                    WavesEnded?.Invoke();
                }
            }
        }
    }

    void OnEnemyPassed(Enemy enemy)
    {
        enemy.Passed -= OnEnemyPassed;
        enemies.Remove(enemy);
    }

    void NextWave()
    {
        currentWave = Waves[nextWaveIndex];
        nextWaveIndex++;
    }

    bool TrySetLastWave()
    {
        isLastWave = nextWaveIndex == Waves.Length;
        return isLastWave;
    }

    public Enemy Spawn(GameObject prefab, Vector3 position)
    {
        Enemy newEnemy = Instantiate(prefab, position, Quaternion.identity).GetComponent<Enemy>();
        enemies.Add(newEnemy);
        newEnemy.Init();
        newEnemy.Passed += OnEnemyPassed;
        EnemySpawned?.Invoke(newEnemy);
        return newEnemy;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}

