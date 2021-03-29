using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class displayTime : MonoBehaviour
{
    public Text FinalTime;
    float finaltime;

    // Start is called before the first frame update
    void Start()
    {
        finaltime = DataSaved.getTime();
        string minutes = ((int)finaltime / 60).ToString();
        string seconds = (finaltime % 60).ToString("f2");
        FinalTime.text = minutes + ":" + seconds;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
