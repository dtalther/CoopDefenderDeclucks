using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMainMenuScript : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GameObject.FindObjectOfType<MainMenu>();
    }

    //Restarts the previous level
    public void RestartLevel()
    {
        mainMenu.startMode(mainMenu.previousLevel);
    }

    //Goes to main menu
    public void GoToMainMenu()
    {
        mainMenu.startMode(0);
    }
}
