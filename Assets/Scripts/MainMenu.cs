using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public MainMenuCharacter mainMenuCharacter;

    public void StartGame()
    {
        mainMenuCharacter.TurnOn();
    }
}
