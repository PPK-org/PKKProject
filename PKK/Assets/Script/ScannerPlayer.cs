using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerPlayer : MonoBehaviour
{
    public GameObject enemy;
    
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "Player")
        {
            enemy.GetComponent<EnemyAI>().setSpeed(400);
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.name == "Player")
        {
            enemy.GetComponent<EnemyAI>().setSpeed(0);
        }
        
    }
    
}
