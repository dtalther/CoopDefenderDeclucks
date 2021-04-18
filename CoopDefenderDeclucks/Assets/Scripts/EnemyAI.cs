using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenu menu;
    //List of the possible drops
    public GameObject spread;
    public GameObject rapid;
    public GameObject slowtime;
    public GameObject shotgun;
    public GameObject machinegun;

    private bool isDead;
    void Awake()
    {
        menu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death()
    {
        if (!isDead) {
            menu.score += 200;
            menu.setGameplayScore(menu.score);
            isDead = true;
            Destroy(gameObject); 
        }
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<PlayerController>().PlayerDeath();
                break;
            case "Bullet":
                dropItem();
                Death();
                break;
        }
    }
    void dropItem()//When an enemy dies they have a chance to drop a weapon or a powerup.
    {
        int num = Random.Range(0, 50);
        print(""+num);
        switch (num)
        {
            case 0://Slow Time
                GameObject st = Instantiate(slowtime);
                st.transform.position = this.transform.position + new Vector3(0, .6f, 0);
                break;
            case 1://Rapid Shot
                GameObject rt = Instantiate(rapid);
                rt.transform.position = this.transform.position + new Vector3(0,.6f,0);
                break;
            case 2://Spread Shot
                GameObject spreg = Instantiate(spread);
                spreg.transform.position = this.transform.position + new Vector3(0, .6f, 0);
                break;
            case 3://Machine Gun
                GameObject mg = Instantiate(machinegun);
                mg.transform.position = this.transform.position + new Vector3(0, .6f, 0);
                break;
            case 4://Shotgun
                GameObject sg = Instantiate(shotgun);
                sg.transform.position = this.transform.position + new Vector3(0, .6f, 0);
                break;


        }
    }
}
