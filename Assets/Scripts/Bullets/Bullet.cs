using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Bullet : MonoBehaviour
{
    public float Speed;
    public float Damage;
    protected Enemy targetEnemy;

    public void Init(Enemy enemy)
    {
        targetEnemy = enemy;
    }

    protected void Move()
    {
        if(!targetEnemy)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, Speed * Time.deltaTime);
        transform.LookAt(targetEnemy.transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
