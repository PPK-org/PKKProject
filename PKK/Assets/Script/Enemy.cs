using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public GameObject gameObject;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isHit");
        currentHealth -= damage;
        // Damage
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        //Die Anim
        Destroy(gameObject);
        //Disable the enemy
    }
}