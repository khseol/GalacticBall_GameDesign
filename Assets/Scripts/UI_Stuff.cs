using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Stuff : MonoBehaviour
{

    GameObject[] pauseMenu;
    Vector3 tempVeloc;
    Vector3 tempAngVeloc;
    Scene curScene;
    string lastBeat;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu = GameObject.FindGameObjectsWithTag("pauseObj");
        dontShowPauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && canScenePause(SceneManager.GetActiveScene()))
        {
            if(Time.timeScale == 1)
            {
                tempVeloc =playerController.rb.velocity;
                tempAngVeloc =playerController.rb.angularVelocity;
                Time.timeScale = 0;
                showPauseMenu();

            }
            else
            {
                Time.timeScale = 1;
                dontShowPauseMenu();
                playerController.rb.velocity = tempVeloc;
                playerController.rb.angularVelocity= tempAngVeloc;
            }

        }


    }

    public void showPauseMenu()
    {
        for (int i = 0; i < pauseMenu.Length; i++)
        {
            pauseMenu[i].SetActive(true);
        }
    }

    public void dontShowPauseMenu()
    {
        for (int i = 0; i < pauseMenu.Length; i++)
        {
            pauseMenu[i].SetActive(false);
        }
    }

    public void load(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

    }


    public void restart()
    {
        curScene = SceneManager.GetActiveScene();
        load(curScene.name);
    }

    public bool canScenePause(Scene activeScene)
    {
        if (activeScene.name.Contains("Level"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void replayLastLevel()
    {
        lastBeat = DataSaved.getLastSceneName();
        load(lastBeat);
    }


}
