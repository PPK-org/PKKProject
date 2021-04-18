using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name=="Player")
        {
            
            DataPlayer.currenthealth = FindObjectOfType<Player>().currenthealth;
            DataPlayer.xposition = FindObjectOfType<Player>().position.x;
            DataPlayer.yposition = FindObjectOfType<Player>().position.y;
            DataPlayer.zposition = FindObjectOfType<Player>().position.z;
            DataPlayer.nextscene = true;
            gameObject.GetComponent<Transition>().LoadNextLevel();
        }
        
        
    }
}
