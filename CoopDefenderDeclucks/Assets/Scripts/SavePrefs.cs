using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    int highScore;
    int levelsCompleted;

    public void SaveScore(int newScore)
    {
        Debug.Log("I save ..");
        highScore = newScore;
        PlayerPrefs.SetInt("HighScoreData", highScore);
        PlayerPrefs.Save();
    }

    public void saveLevelProgress(int levelVal)
    {
        levelsCompleted = levelVal;
        PlayerPrefs.SetInt("LevelProgressData", levelsCompleted);
        PlayerPrefs.Save();
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("HighScoreData");
        PlayerPrefs.DeleteKey("LevelProgressData");
        Debug.Log("Save data reset...");
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("HighScoreData"))
        {
            highScore = PlayerPrefs.GetInt("HighScoreData");
            Debug.Log("High Score save data loaded!  It's "+ highScore);
        }
        if (PlayerPrefs.HasKey("LevelProgressData"))
        {
            levelsCompleted = PlayerPrefs.GetInt("LevelProgressData");
            Debug.Log("Level Progress Data saved! It's "+levelsCompleted);
        }
        if(!PlayerPrefs.HasKey("HighScoreData") && !PlayerPrefs.HasKey("LevelProgressData"))
        {
            Debug.Log("THERE IS NO SAVE DATA!");
            highScore = 0;
            levelsCompleted = 0;
        }
    }

    //Gets the best score the player has gotten
    public int GetBestScore()
    {
        return highScore;
    }

    //Gets the amount of campaign levels the player completed
    public int GetLevelsCompleted()
    {
        return levelsCompleted;
    }
}
