using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Player player;
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronusly(sceneIndex));
    }

    IEnumerator LoadAsynchronusly (int sceneIndex)
    {
        DataPlayer.currenthealth = 100;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            slider.value = progress;

            yield return null;
        }
    }
    public void play()
    {
        DataPlayer.Resume = false;
        DataPlayer.eventCount = 0;
        LoadLevel(1);
    }
    public void Resume()
    {
        DataPlayer.Resume = true;
        DataPlayer data = SaveSystem.LoadPlayer();
        DataPlayer.xposition = data.position[0];
        DataPlayer.yposition = data.position[1];
        DataPlayer.zposition = data.position[2];
        DataPlayer.Resume = true;
        LoadLevel(data.level);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
