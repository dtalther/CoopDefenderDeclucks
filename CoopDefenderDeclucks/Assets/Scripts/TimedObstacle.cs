using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObstacle : MonoBehaviour
{
    public float timer;
    public GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
