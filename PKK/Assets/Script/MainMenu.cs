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
        DataPlayer.resume = false;
        DataPlayer.eventCount = 0;
        LoadLevel(1);
    }
    public void Resume()
    {
        //Android.reader_function();
        //DataPlayer data = SaveSystem.LoadPlayer();
        DataPlayer.resume = true;
        if(DataPlayer.level != 0)
        {
            LoadLevel(DataPlayer.level);
        }else
        {
            LoadLevel(1);
        }
        
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
