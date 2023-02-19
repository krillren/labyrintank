using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public static void startLevel(int i)
    {
        SceneManager.LoadScene("level" + i);
        Time.timeScale = 1;
    }
    public static void startSurvival()
    {
        SceneManager.LoadScene("survival");
        Time.timeScale = 1;
    }
    public static void menu()
    {
        SceneManager.LoadScene("menu");
    }
}
