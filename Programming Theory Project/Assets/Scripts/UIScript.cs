using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private static float _metal=0;
    private static float _rocks = 0;
    private static float _food = 0;
    private static float _wood = 0;

    public Text _metalText;
    public Text _rocksText;
    public Text _foodText;
    public Text _woodText;

    public void Update()
    {
        _metalText.text = $"Metal:   {Math.Round(_metal,2)}";
        _rocksText.text = $"Rocks:  {Math.Round(_rocks, 2)}";
        _foodText.text = $"Food:    {Math.Round(_food, 2)}";
        _woodText.text = $"Wood:   {Math.Round(_wood, 2)}";
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
        var dCount = count * Time.deltaTime;
        switch (_type)
        {
            case ResourceType.FoodField:
                _food += dCount;
                break;
            case ResourceType.Metal:
                _metal += dCount;
                break;
            case ResourceType.Rocks:
                _rocks += dCount;
                break;
            case ResourceType.Tree:
                _wood += dCount;
                break;
        }
        
    }
}
