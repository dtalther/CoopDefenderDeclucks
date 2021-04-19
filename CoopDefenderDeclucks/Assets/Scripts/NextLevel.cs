using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public MainMenu menuManager;
    private void Start()
    {
        menuManager = GameObject.FindObjectOfType<MainMenu>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Level Complete");
            menuManager.startMode(6);
        }
    }
}
