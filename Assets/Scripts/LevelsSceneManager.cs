using System.Collections;
using System.Collections.Generic;
using MPack;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelsSceneManager : MonoBehaviour
{
    public static LevelsSceneManager ins;

    public int levelName = 1;

    public int finalLevel;

    public Image transitionImage;
    public Timer transitionTimer;

    private AsyncOperation loadProgress;
    private Canvas canvas;

    private string sceneName;

    void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName != "MainMenu")
        {
            levelName = int.Parse(sceneName.Substring(6));
        }

        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = enabled = false;
    }

    void Update()
    {
        if (transitionTimer.UnscaleUpdateTimeEnd)
        {
            if (!transitionTimer.ReverseMode)
            {
                SceneManager.LoadScene(sceneName);
                Time.timeScale = 1;
                transitionTimer.ReverseMode = true;
                // transitionTimer.Reset();
            }
            else
            {
                canvas.enabled = enabled = false;
                transitionImage.color = new Color(0, 0, 0, 0);
                return;
            }
        }

        transitionImage.color = new Color(0, 0, 0, transitionTimer.Progress);
    }

    public void StartGame()
    {
        StartLoadingScene("Level-" + levelName);
    }

    public void ReloadLevel()
    {
        StartLoadingScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        if (levelName >= finalLevel)
        {
            StartLoadingScene("GameFinished");
        }
        else
        {
            StartLoadingScene("Level-" + (++levelName));
        }
    }

    public void MainMenu()
    {
        levelName = 1;
        StartLoadingScene("MainMenu");
    }

    public void StartLoadingScene(string sceneName)
    {
        this.sceneName = sceneName;
        transitionImage.color = new Color(0, 0, 0, 0);
        transitionTimer.Reset();
        canvas.enabled = enabled = true;
        transitionTimer.ReverseMode = false;
    }
}
