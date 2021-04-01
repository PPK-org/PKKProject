using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    // Start is called before the first frame updatepublic Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    float nextAtktime= 0f;
    public float attackRate = 2f;
    void Update()
    {
        if (Time.time >= nextAtktime)
        {
            
            Atk();
            nextAtktime = Time.time + 2f / attackRate;
            
        } 

    }
    void Atk()
    {
        // detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // damage them
        foreach(Collider2D Player in hitEnemies)
        {
            
            Player.GetComponent<Player>().TakeDamage(attackDamage);
        }
       
    }

}
