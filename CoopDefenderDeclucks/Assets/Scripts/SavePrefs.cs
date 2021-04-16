using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    int highScore;

    public void SaveScore(int newScore)
    {
        highScore = newScore;
        PlayerPrefs.SetInt("HighScoreData", highScore);
        PlayerPrefs.Save();
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("HighScoreData"))
        {
            highScore = PlayerPrefs.GetInt("HighScoreData");
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.Log("THERE IS NO SAVE DATA!");
            highScore = 0;
        }
    }

    //Gets the best score the player has gotten
    public int GetBestScore()
    {
        return highScore;
    }
}
