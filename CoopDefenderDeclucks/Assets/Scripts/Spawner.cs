using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnpoint;
    public GameObject enemytype;
    public float spawnrate;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > spawnrate)
        {
            SpawnEnemy();
            time = 0;
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemytype, spawnpoint[0].transform.position, Quaternion.identity);
    }
}
