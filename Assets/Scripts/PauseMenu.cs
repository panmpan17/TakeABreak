using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // public GameObject skipAlert;

    // private Canvas canvas;
    public GameObject menu;

    void Awake()
    {
        menu.SetActive(false);
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        LevelsSceneManager.ins.ReloadLevel();
    }

    public void Skip()
    {
        LevelsSceneManager.ins.NextLevel();
    }

    public void MainMenu()
    {
        LevelsSceneManager.ins.MainMenu();
    }
}
