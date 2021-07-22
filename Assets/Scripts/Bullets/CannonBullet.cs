using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : Bullet
{

    void Update()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy == targetEnemy)
        {
            enemy.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
