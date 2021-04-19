using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morpheus_Dorpheus : MonoBehaviour
{
    MainMenu gameManager;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gameManager = FindObjectOfType<MainMenu>();
            //You already know what it is
            if (gameManager.getSaveManager().GetLevelsCompleted() >= 3)
            {
                gameObject.SetActive(true);
                if (transform.parent != null)
                    gameObject.transform.SetParent(transform.parent);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        catch (System.Exception error)
        {
            print("You got morpheused!" + error.Message);
        }
    }

}
