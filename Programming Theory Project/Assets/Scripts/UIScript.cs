using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void MenuStartApp()
    {
        SceneManager.LoadScene("main");
    }

    public void MenuExit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void MainExitMenu()
    {
        SceneManager.LoadScene("title-screen");
    }
}
