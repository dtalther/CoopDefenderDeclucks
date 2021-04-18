using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenu menu;
    void Awake()
    {
        menu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death()
    {
        menu.score += 200;
        menu.setGameplayScore(menu.score);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<PlayerController>().PlayerDeath();
                break;
            case "Bullet":
                Death();
                break;
        }
    }
}
