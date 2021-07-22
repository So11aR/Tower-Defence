using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public float BurstRadius;
    public float SecondDamage;
    public ParticleSystem BurstEffect;
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
        
        BurstEffect.gameObject.transform.SetParent(null);
        BurstEffect.transform.position = enemy.transform.position;
        BurstEffect.Play();

        Collider[] hits = Physics.OverlapSphere(enemy.transform.position, BurstRadius);
        foreach(var hit in hits)
        {
            Enemy secondEnemy = hit.GetComponent<Enemy>();
            if(secondEnemy)
            {
                secondEnemy.TakeDamage(SecondDamage);
            }
        }

        Destroy(gameObject);
    }
}
