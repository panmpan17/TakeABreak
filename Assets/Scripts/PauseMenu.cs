using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public RectTransform autoFocusUIElement;

    // private Canvas canvas;
    public GameObject menu;

    private PlayerInput m_input;

    void Awake()
    {
        menu.SetActive(false);

        m_input = new PlayerInput();
        m_input.OnGround.Pause.started += TogglePressed;
    }

    void OnEnable() { m_input.Enable(); }
    void OnDisable() { m_input.Disable(); }

    void TogglePressed(InputAction.CallbackContext callback)
    {
        if (menu.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(autoFocusUIElement.gameObject);
        // autoFocusUIElement.ForceUpdateRectTransforms();
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
