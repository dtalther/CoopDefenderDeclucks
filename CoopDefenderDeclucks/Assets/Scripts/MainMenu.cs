using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Btn_ClassicMode;
    [SerializeField] private Button Btn_CampaignMode;
    [SerializeField] private Button Btn_QuitGame;
    [SerializeField] private Button Btn_Resume;
    [SerializeField] private Text Txt_Title;

    private Canvas menuCanvas;//Actual canvas gameobject
    private static MainMenu menuInstance;//Reference to this script to make sure double spawn doesn't occur

    public bool isPaused;//Determines whether the game is paused or not

    public int currentScene;//Represents the current scene in play

    public int score;//Score

    private float previousTimeScale;//Used to unpause game and set it back to the previous time scale

    // Start is called before the first frame update
    void Awake()
    {
        Object.DontDestroyOnLoad(this);
        if (menuInstance == null)
            menuInstance = this;
        else
            Object.Destroy(this.gameObject);
        previousTimeScale = 0;
        isPaused = false;
        currentScene = 0;
        Btn_Resume.gameObject.SetActive(false);
        menuCanvas = transform.GetChild(0).GetComponent<Canvas>();

        currentScene = SceneManager.GetActiveScene().buildIndex;
        setMenuUI(currentScene);
    }

    //Update function
    void Update()
    {
        //Pauses game if player presses escape and game is not paused
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false && currentScene != 0)
        {
            pauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true && currentScene != 0)
        {
            unpauseGame();
        }
    }

    public void setMenuUI(int sceneValue)
    {
        //If the the scene value is 0 and the current scene is 0, quit the game
        if (sceneValue == 0 && currentScene == 0)
            Application.Quit();
        else
        {
            currentScene = sceneValue;
            if (currentScene > 0)//When scene updates, update menu
            {
                Txt_Title.gameObject.SetActive(false);
                Btn_ClassicMode.gameObject.SetActive(false);
                Btn_CampaignMode.gameObject.SetActive(false);
                Btn_QuitGame.gameObject.SetActive(false);
                Btn_Resume.gameObject.SetActive(true);
                isPaused = false;
                menuCanvas.gameObject.SetActive(false);
            }
            else if (currentScene < 1)//If scene val is less than 1, load main menu
            {
                Time.timeScale = 1;
                Btn_ClassicMode.gameObject.SetActive(true);
                Btn_CampaignMode.gameObject.SetActive(true);
                Btn_Resume.gameObject.SetActive(false);
                Txt_Title.gameObject.SetActive(true);
                currentScene = 0;
                menuCanvas.gameObject.SetActive(true);
            }
        }
    }

    //Starts a scene based on its scene value
    public void startMode(int sceneValue)
    {
        //If the the scene value is 0 and the current scene is 0, quit the game
        if (sceneValue == 0 && currentScene == 0)
            Application.Quit();
        else
        {
            currentScene = sceneValue;
            if(currentScene > 0)//When scene updates, update menu
            {
                Txt_Title.gameObject.SetActive(false);
                Btn_ClassicMode.gameObject.SetActive(false);
                Btn_CampaignMode.gameObject.SetActive(false);
                Btn_QuitGame.gameObject.SetActive(false);
                Btn_Resume.gameObject.SetActive(true);
                isPaused = false;
                menuCanvas.gameObject.SetActive(false);
            }
            else if(currentScene < 1)//If scene val is less than 1, load main menu
            {
                Time.timeScale = 1;
                Btn_ClassicMode.gameObject.SetActive(true);
                Btn_CampaignMode.gameObject.SetActive(true);
                Btn_Resume.gameObject.SetActive(false);
                Txt_Title.gameObject.SetActive(true);
                currentScene = 0;
                menuCanvas.gameObject.SetActive(true);
            }
            SceneManager.LoadScene(sceneValue);
        }
    }

    //Pauses the game
    public void pauseGame()
    {
        previousTimeScale = Time.timeScale;
        isPaused = true;
        //menuCanvas.enabled = true;
        Btn_Resume.gameObject.SetActive(true);
        Btn_QuitGame.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //Unpauses the game
    public void unpauseGame()
    {
        isPaused = false;
        Btn_Resume.gameObject.SetActive(false);
        Btn_QuitGame.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(false);
        Time.timeScale = previousTimeScale;
        //menuCanvas.enabled = false;
    }
}
