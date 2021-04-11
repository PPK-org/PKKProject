using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject screen;
    public Player player;
    public void Savebtn(){
        DataPlayer.level = player.level;
        DataPlayer.eventCount = player.eventCount;
        DataPlayer.xposition = player.transform.position.x;
        DataPlayer.yposition = player.transform.position.y;
        DataPlayer.zposition = player.transform.position.z;
        // Debug.Log(DataPlayer.level);
        // Debug.Log(DataPlayer.eventCount);
        // Debug.Log(DataPlayer.xposition);
        // Debug.Log(DataPlayer.yposition);
        // Debug.Log(DataPlayer.zposition);
        screen.SetActive(false);
        Time.timeScale = 1f;
    }
}
