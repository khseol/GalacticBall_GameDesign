using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{

    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag =="Player")
        {
            load("Win");
        }
    }


    public void load(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

    }
}