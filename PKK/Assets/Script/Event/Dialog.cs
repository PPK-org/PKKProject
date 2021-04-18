using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay, textNama;
    //public string[] sentences;
    //private int index;
    public int indexs;
    public float typingSpeed;
    public GameObject dialog;
    public GameObject continueButton;
    // Start is called before the first frame update
    
    void Start(){
        
    }
    IEnumerator Type(){
        foreach (char letter in DialogText.sentences[DialogText.index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        continueButton.SetActive(false);
        if(DialogText.index < DialogText.sentences.Length - 1){
            DialogText.index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else{
            textDisplay.text = "";
            DataPlayer.eventPlay = false;
            DataPlayer.eventCount++;
            //Debug.Log(DataPlayer.eventCount);
            dialog.SetActive(false);
            continueButton.SetActive(false);
            //Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        textNama.text = DialogText.namadialog;
        //Debug.Log(DataPlayer.eventCount);
        if(DataPlayer.eventCount == indexs){
            if(DataPlayer.eventPlay == false)
            {
                dialog.SetActive(true);
                StartCoroutine(Type());
                DataPlayer.eventPlay = true;
            }else{
                //Debug.Log("masuk");
                //Debug.Log(textDisplay.text);
                //Debug.Log("index "+DialogText.index);
                if(textDisplay.text == DialogText.sentences[DialogText.index])
                {
                    //Debug.Log("masuk");
                    continueButton.SetActive(true);
                }
            }
            
        }
        
    }
    
}
