using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public float baseExplodeTimeAmount;
    [SerializeField] private float Timer;

    public GameObject[] Generators;
    private int generatorCnt;

    private GameObject Door;
    public GameObject[] PowerCores;

    private GameObject exitCheck;

    private int powerCoreCnt;
    private MainMenu gameManager;
    public GameObject Explosion;

    public Spawner [] DoorSpawners;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<MainMenu>();
        exitCheck = GameObject.FindGameObjectWithTag("ExitCheck");
        exitCheck.SetActive(false);
        Door = GameObject.FindGameObjectWithTag("Door");
        Generators = GameObject.FindGameObjectsWithTag("Generator");
        PowerCores = GameObject.FindGameObjectsWithTag("PowerCore");
        powerCoreCnt = PowerCores.Length;
        generatorCnt = Generators.Length;
        Timer = baseExplodeTimeAmount;
    }

    void Update()
    {
        if(powerCoreCnt <= 0 && Time.timeScale > 0)
        {
            Timer -= Time.deltaTime/Time.timeScale;
            if(Timer <= 0)
            {
                gameManager.startMode(5);
            }
        }
    }

    public void checkGeneratorProgress()
    {
        generatorCnt--;
        if (generatorCnt <= 0)
        {
            Instantiate(Explosion, Door.transform.position, Door.transform.rotation).transform.localScale *= 6;
            Destroy(Door);
            DoorSpawners[0].gameObject.SetActive(true);
            DoorSpawners[1].gameObject.SetActive(true);
        }
    }

    public void checkPowerCoreProgress()
    {
        powerCoreCnt--;
        if (powerCoreCnt <= 0)
        {
            exitCheck.SetActive(true);
        }
    }
}
