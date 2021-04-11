using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Test : MonoBehaviour
{
    public TextMeshProUGUI textDate1, textDate2, textDate3, textDate4 , textSave1,textSave2,textSave3,textSave4;
    public string sentences;
    
    public int index;
    //public float typingSpeed;
    //public GameObject dialog;
    //public GameObject continueButton;
    // Start is called before the first frame update
    
    void Start(){
        
    }
    
    // Update is called once per frame
    void Update()
    {
        sentences = string.Format("Update Savedat set resume = \"{0}\", currenthealth = \"{1}\", xposition =\"{2}\", yposition =\"{3}\", zposition =\"{4}\", eventPlay =\"{5}\", backscene =\"{6}\", eventCount =\"{7}\", level =\"{8}\"", DataPlayer.resume, DataPlayer.currenthealth, DataPlayer.xposition, DataPlayer.yposition, DataPlayer.zposition, DataPlayer.eventPlay, DataPlayer.backscene, DataPlayer.eventCount, DataPlayer.level);
        //textDisplay.text = sentences;
    }
    public void TextDisplay()
    {
        textSave1.text = "Data "+DataPlayer.id[0];
        textSave2.text = "Data "+DataPlayer.id[1];
        textSave3.text = "Data "+DataPlayer.id[2];
        textSave4.text = "Data "+DataPlayer.id[3];
        textDate1.text = "Last Save "+DataPlayer.DateTimes[0];
        textDate2.text = "Last Save "+DataPlayer.DateTimes[1];
        textDate3.text = "Last Save "+DataPlayer.DateTimes[2];
        textDate4.text = "Last Save "+DataPlayer.DateTimes[3];
    }
    
}
