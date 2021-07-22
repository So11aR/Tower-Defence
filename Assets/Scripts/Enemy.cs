using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float MaxHealth;
    private float currentHealth;
    private EnemyMover mover;
    private HealthBar healthBar;
    private Animator animator;

    public event UnityAction<Enemy> Died;
    public event UnityAction<Enemy> Passed;
    // Start is called before the first frame update
    public void Init()
    {
        currentHealth = MaxHealth;
        mover = GetComponent<EnemyMover>();
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.UpdateHealthBar(currentHealth, MaxHealth);
    }

    // Update is called once per frame
    void Die()
    {
        Died?.Invoke(this);
        mover.enabled = false;
        healthBar.gameObject.SetActive(false);
        animator.Play("Die");
        Destroy(gameObject, 2.1f);
    }

    public void TakeDeceleration(float degree, float delay)
    {
        degree = Mathf.Clamp(degree, 0, 100);
        float normalSpeed = mover.Speed;
        mover.Speed -= degree * mover.Speed;
        StartCoroutine(CancelDeceleration(delay, normalSpeed));
    }

    IEnumerator CancelDeceleration(float delay, float normalSpeed)
    {
        yield return new WaitForSeconds(delay);
        mover.Speed = normalSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, MaxHealth);
        if(currentHealth < 0)
        {
            Die();
        }
    }

    public void Pass()
    {
        Passed?.Invoke(this);
        Destroy(gameObject);
    }
}

[System.Serializable]
public class Wave 
{
    public int Capacity;
    public GameObject EnemyPrefab;
    public float TimeBetweenSpawn;
    public float Delay;
}