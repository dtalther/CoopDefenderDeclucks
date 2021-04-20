using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Manager : MonoBehaviour
{
    public Text Txt_Objective;
    public Text Txt_ObjectiveIntro;
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
    public AudioSource[] sirens;
    public Light[] doorLights;

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
        Txt_ObjectiveIntro.text = "Destroy "  +generatorCnt+ " Generators";
        Txt_Objective.text = 0 + "/" +generatorCnt+ " Generators Destroyed";
        sirens[0].gameObject.SetActive(true);
    }

    void Update()
    {
        if(powerCoreCnt <= 0 && Time.timeScale > 0)
        {
            Timer -= Time.deltaTime/Time.timeScale;
            Txt_Objective.text = Mathf.Round(Timer) + " seconds left!";
            if(Timer <= 0)
            {
                gameManager.startMode(5);
            }
        }
    }

    public void checkGeneratorProgress()
    {
        generatorCnt--;
        Txt_Objective.text = (8 - generatorCnt) + "/8 Generators Destroyed";
        if (generatorCnt <= 0)
        {
            Txt_ObjectiveIntro.text = "Destroy 3 Power Cores";
            Txt_Objective.text = (3 - powerCoreCnt) + "/3 Power Cores Destroyed";
            Instantiate(Explosion, Door.transform.position, Door.transform.rotation).transform.localScale *= 6;
            Destroy(Door);
            DoorSpawners[0].gameObject.SetActive(true);
            DoorSpawners[1].gameObject.SetActive(true);
            doorLights[0].color = Color.green;
            doorLights[1].color = Color.green;
        }
    }

    public void checkPowerCoreProgress()
    {
        powerCoreCnt--;
        Txt_Objective.text = (3 - powerCoreCnt) + "/3 Power Cores Destroyed";
        if (powerCoreCnt <= 0)
        {
            Txt_Objective.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            Txt_Objective.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

            Txt_ObjectiveIntro.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            Txt_ObjectiveIntro.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

            Txt_Objective.alignment = TextAnchor.MiddleCenter;
            Txt_ObjectiveIntro.alignment = TextAnchor.MiddleCenter;

            Txt_Objective.rectTransform.anchoredPosition = new Vector2(0, 100);
            Txt_ObjectiveIntro.rectTransform.anchoredPosition = new Vector2(0, 200);

            Txt_ObjectiveIntro.text = "Escape the base!";
            Txt_ObjectiveIntro.fontSize = 25;
            Txt_Objective.fontSize = 25;
            Txt_ObjectiveIntro.color = Color.red;
            Txt_Objective.color = Color.red;
            exitCheck.SetActive(true);
            sirens[0].gameObject.SetActive(true);
            sirens[1].gameObject.SetActive(true);
        }
    }
}
