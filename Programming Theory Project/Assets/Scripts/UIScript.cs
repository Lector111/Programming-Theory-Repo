using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private ulong _metal=0;
    private ulong _rocks = 0;
    private ulong _food = 0;
    private ulong _wood = 0;

    public Text _metalText;
    public Text _rocksText;
    public Text _foodText;
    public Text _woodText;

    public void Update()
    {
        _metalText.text = $"Metal:   {_metal}";
        _rocksText.text = $"Rocks:  {_rocks}";
        _foodText.text = $"Food:    {_food}";
        _woodText.text = $"Wood:   {_wood}";
    }

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

    public static void CountResource(ResourceType _type,int count)
    {

    }
}
