using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger1 : MonoBehaviour
{
    public int index;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(DataPlayer.eventCount == index){
            if(col.gameObject.name == "Player"){
                DialogText.EventText();
                DataPlayer.eventCount = index+1;
                //Debug.Log(DataPlayer.eventCount);
            }
        }
    }
}
