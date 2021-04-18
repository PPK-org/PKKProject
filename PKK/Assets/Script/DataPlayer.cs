using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class DataPlayer
{
    public static bool resume;
    public static int currenthealth = 100;
    public static int level;
    public float[] position;
    public static float xposition;
    public static float yposition;
    public static float zposition;
    public static bool eventPlay;
    public static bool backscene;
    public static int eventCount = 0;
    public static bool nextscene;
    public static bool checkcheckpoint;
    public static int[] id = new int[4];
    public static string datetimenow;
    public static string [] DateTimes = new string[4];
    public DataPlayer (Player player)
    {
        level = player.level;
        eventCount = player.eventCount;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    public static void Datetimenow()
    {
        datetimenow = DateTime.Now.ToString();
    }
}
