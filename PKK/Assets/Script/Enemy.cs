using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public GameObject gameObject;
    public Rigidbody2D _rigidbody;
    public Transform obj;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        Vector2 finddi = obj.transform.position - transform.position;
        // Debug.Log(finddi);
        Debug.Log(new Vector2((-finddi.x < 0?-1:1) * 250f  ,0f));
        _rigidbody.AddForce(new Vector2((-finddi.x < 0?-1:1) * 300f  ,0f));
        // Damage
        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("hit");
        animator.SetTrigger("isHit");
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        //Die Anim
        Destroy(gameObject);
        //Disable the enemy
    }
}