using System.Security.Authentication;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackplayer : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    float nextAtktime= 0f;
    public float attackRate = 2f;
    void Update()
    {
        if (DataPlayer.eventPlay == true)
        {
            
        }else{
        if (Time.time >= nextAtktime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Atk();
                nextAtktime = Time.time + 0.5f / attackRate;
            }
        }
        }
    }

    void Atk()
    {
        // play anim
        animator.SetTrigger("isAtk");
        // detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);    
    }
}
