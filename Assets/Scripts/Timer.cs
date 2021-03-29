using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float lvlTime;
    public Text Clock;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        lvlTime -= Time.deltaTime;

        string minutes = ((int)lvlTime / 60).ToString();
        string seconds = (lvlTime % 60).ToString("f2");
        Clock.text = minutes + ":" + seconds;

        if (lvlTime < 0)
        {
            timeOut();
        }

        DataSaved.setTime(lvlTime);
    }

    void timeOut()
    {
        SceneManager.LoadSceneAsync("Death");
    }

    public float getCurTime()
    {
        return lvlTime;
    }

}
