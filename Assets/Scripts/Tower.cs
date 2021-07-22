using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float AttackSpeed;
    public float AttackRadius;
    public Bullet BulletPrefab;
    public Transform ShootPoint;
    private List<Enemy> enemies;
    private Spawner Spawner;
    private Enemy targetEnemy;
    private float timer = 0;

    public void Init(Spawner spawner)
    {
        Spawner = spawner;
        enemies = spawner.GetEnemies();
        foreach(var enemy in enemies)
        {
            enemy.Died += OnEnemyDied;
        }

        Spawner.EnemySpawned += OnEnemySpawned;
        InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);
    }

    void OnDisable()
    {
        Spawner.EnemySpawned -= OnEnemySpawned;
    }

    void OnEnemySpawned(Enemy newEnemy)
    {
        newEnemy.Died += OnEnemyDied;
    }

    void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        enemies.Remove(enemy);
        targetEnemy = null;
    }
    
    void Update()
    {
        if(targetEnemy != null)
        {
            timer += Time.deltaTime;
            if(timer >= AttackSpeed)
            {
                Shoot(targetEnemy);
                timer = 0;
            }
        }
    }

    void UpdateTarget()
    {
        Enemy nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach(var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy && shortestDistance <= AttackRadius)
        {
            targetEnemy = nearestEnemy;
        }
    }

    void Shoot(Enemy target)
    {
        Bullet bullet = Instantiate(BulletPrefab, ShootPoint.position, Quaternion.identity);
        bullet.Init(targetEnemy);
    }
}
