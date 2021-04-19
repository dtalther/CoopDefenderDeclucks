using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Btn_ClassicMode;
    [SerializeField] private Button Btn_CampaignLevel1;
    [SerializeField] private Button Btn_CampaignLevel2;
    [SerializeField] private Button Btn_CampaignLevel3;
    [SerializeField] private Button Btn_QuitGame;
    [SerializeField] private Button Btn_Resume;
    [SerializeField] private Text Txt_Title;
    [SerializeField] private Text Txt_HighScore;
    [SerializeField] private Text Txt_GameplayScore;

    private Canvas menuCanvas;//Actual canvas gameobject
    private static MainMenu menuInstance;//Reference to this script to make sure double spawn doesn't occur
    protected SavePrefs saveManager;

    public bool isPaused;//Determines whether the game is paused or not
    private bool isGameplaying;//Determines whether the player is playing a game mode or not

    public int currentScene;//Represents the current scene in play
    public int previousLevel;//Represents the previous level that the player was in

    public int score;//current score of the player during gameplay
    public int highScore;//Highest recorded score from the player

    private float previousTimeScale;//Used to unpause game and set it back to the previous time scale

    // Start is called before the first frame update
    void Awake()
    {
        Object.DontDestroyOnLoad(this);
        if (menuInstance == null)
            menuInstance = this;
        else
            Object.Destroy(this.gameObject);

        saveManager = GetComponent<SavePrefs>();
        saveManager.LoadGameData();

        highScore = saveManager.GetBestScore();

        //saveManager.ResetSave();

        setHighScore(highScore);

        isGameplaying = false;
        score = 0;
        previousTimeScale = 0;
        isPaused = false;
        currentScene = 0;
        previousLevel = 0;
        Btn_Resume.gameObject.SetActive(false);
        menuCanvas = transform.GetChild(0).GetComponent<Canvas>();

        currentScene = SceneManager.GetActiveScene().buildIndex;

        startMode(currentScene, false);
    }

    //Update function
    void Update()
    {
        //gameplayScorePos = new Vector3(Scree, Screen.height/2.15f, 0);
        //Pauses game if player presses escape and game is not paused
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false && currentScene != 0 && isGameplaying)
        {
            pauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true && currentScene != 0 && isGameplaying)
        {
            unpauseGame();
        }
    }

    //Restarts whatever current level the player was on
    public void restartLevel()
    {
        startMode(previousLevel);
    }

    //Overloaded method for button presses
    public void startMode(int sceneValue)
    {
        startMode(sceneValue, true);
    }

    //Starts a scene based on its scene value
    public void startMode(int sceneValue, bool switchScenes)
    {
        previousLevel = currentScene;
        //If the the scene value is 0 and the current scene is 0, quit the game
        if (sceneValue == -1 && currentScene == 0)
            Application.Quit();
        else
        {
            currentScene = sceneValue;
            if(currentScene > 0)//When scene updates, update menu
            {
                if (currentScene < 5)//If not on end screen, do the following
                {
                    score = 0;
                    isGameplaying = true;
                    Txt_GameplayScore.gameObject.SetActive(true);
                }
                else//else if on end screen
                {
                    isGameplaying = false;
                    Txt_GameplayScore.gameObject.SetActive(false);
                }
                setGameplayScore(score);
                Txt_Title.gameObject.SetActive(false);
                Txt_HighScore.gameObject.SetActive(false);

                Btn_ClassicMode.gameObject.SetActive(false);
                Btn_QuitGame.gameObject.SetActive(false);

                Btn_CampaignLevel1.gameObject.SetActive(false);
                Btn_CampaignLevel2.gameObject.SetActive(false);
                Btn_CampaignLevel3.gameObject.SetActive(false);

                //Btn_Resume.gameObject.SetActive(true);
                isPaused = false;
                //menuCanvas.gameObject.SetActive(false);
            }
            else if(currentScene < 1)//If scene val is less than 1, load main menu
            {
                print("saved high score data is " + saveManager.GetBestScore());
                isGameplaying = false;
                score = 0;
                setHighScore(highScore);
                Time.timeScale = 1;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;

                Btn_ClassicMode.gameObject.SetActive(true);
                Btn_QuitGame.gameObject.SetActive(true);
                Btn_Resume.gameObject.SetActive(false);

                Btn_CampaignLevel1.gameObject.SetActive(true);
                Btn_CampaignLevel2.gameObject.SetActive(true);
                Btn_CampaignLevel3.gameObject.SetActive(true);
                checkCampaignLevelStatus();

                Txt_Title.gameObject.SetActive(true);
                Txt_HighScore.gameObject.SetActive(true);
                Txt_GameplayScore.gameObject.SetActive(false);
                currentScene = 0;
                //menuCanvas.gameObject.SetActive(true);
            }
            //If in win screen, check and update player progress
            if(currentScene == 6)
            {
                //Checks to see if player has completed up to 3 levels
                if(saveManager.GetLevelsCompleted() < 3)
                {
                    if((previousLevel == 2 && saveManager.GetLevelsCompleted() < 1) || (previousLevel == 3 && saveManager.GetLevelsCompleted() < 2) || (previousLevel == 4 && saveManager.GetLevelsCompleted() < 3))
                        saveManager.SaveLevelProgress(saveManager.GetLevelsCompleted() + 1);
                }
            }
            if(switchScenes == true)
                SceneManager.LoadScene(currentScene);
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
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    //Unpauses the game
    public void unpauseGame()
    {
        isPaused = false;
        Btn_Resume.gameObject.SetActive(false);
        Btn_QuitGame.gameObject.SetActive(false);
        //menuCanvas.gameObject.SetActive(false);
        Time.timeScale = previousTimeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        //menuCanvas.enabled = false;
    }

    public void setGameplayScore(int scoreVal)
    {
        score = scoreVal;
        Txt_GameplayScore.text = "Score:  " + score;
    }

    //sets high score text
    public void setHighScore(int scoreVal)
    {
        highScore = scoreVal;
        Txt_HighScore.text = "High Score:  " + highScore;
    }

    //Returns save manager
    public SavePrefs getSaveManager()
    {
        return saveManager;
    }

    //Sets the game state
    public void setGameState(bool state)
    {
        isGameplaying = state;
    }

    //Activates buttons based on campaign level status
    public void checkCampaignLevelStatus()
    {
        if(saveManager.GetLevelsCompleted() >= 1)
        {
            Btn_CampaignLevel2.interactable = true;
        }
        else
        {
            Btn_CampaignLevel2.interactable = false;
        }
        if(saveManager.GetLevelsCompleted() >= 2)
        {
            Btn_CampaignLevel3.interactable = true;
        }
        else
        {
            Btn_CampaignLevel3.interactable = false;
        }
    }
}
