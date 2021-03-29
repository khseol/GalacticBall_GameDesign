using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            load("Death");
        }
    }


    public void load(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

    }
}
