using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(DataPlayer.eventCount == 0){
            if(col.gameObject.name == "Player"){
            DataPlayer.eventCount = 1;
            }
        }
    }
}
