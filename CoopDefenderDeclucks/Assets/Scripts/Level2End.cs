using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2End : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ruthRescued;
    public MainMenu menuManager;
    public GameObject arrow;
    void Start()
    {
        ruthRescued = false;
        menuManager = GameObject.FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ally")
        {
            ruthRescued = true;
            arrow.SetActive(true);
        }            
        if(other.gameObject.tag == "Player" && ruthRescued)
        {
            print("Level Complete");
            menuManager.startMode(6);
        }
    }
}
