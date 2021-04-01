using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject dialog;
    public GameObject continueButton;
    // Start is called before the first frame update
    
    void Start(){
        
    }
    IEnumerator Type(){
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        continueButton.SetActive(false);
        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else{
            textDisplay.text = "";
            DataPlayer.eventPlay = false;
            DataPlayer.eventCount = 2;
            dialog.SetActive(false);
            continueButton.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(DataPlayer.eventCount == 1){
            if(DataPlayer.eventPlay == false)
            {
                dialog.SetActive(true);
                StartCoroutine(Type());
                DataPlayer.eventPlay = true;
            }else{
                if(textDisplay.text == sentences[index]){
                continueButton.SetActive(true);
            }
            }
            
        }
        
    }
    
}
