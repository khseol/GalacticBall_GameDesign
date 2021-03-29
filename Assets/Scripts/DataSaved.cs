using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DataSaved
{
    private static float finalTime;
    private static string lastScene;


    public static void setTime(float time)
    {
        finalTime = 60.0f - time;
    }

    public static float getTime()
    {
        return finalTime;
    }

    public static void setLastSceneName(Scene before)
    {
        lastScene = before.name;
    }

    public static string getLastSceneName()
    {
        return lastScene;
    }

    
}
