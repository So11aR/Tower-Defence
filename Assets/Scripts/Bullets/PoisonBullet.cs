using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : Bullet
{
    public float DecelerationDegree;
    public float ActionTime;

    void Update()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy == targetEnemy)
        {
            DecelerationDegree /= 100;
            enemy.TakeDamage(Damage);
            enemy.TakeDeceleration(DecelerationDegree, ActionTime);
        }
        Destroy(gameObject);
    }
}
