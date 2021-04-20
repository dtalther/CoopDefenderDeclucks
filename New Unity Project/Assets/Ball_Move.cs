using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Move : MonoBehaviour
{
    public float timer = 0;
    public bool flag1, flag2, flag3, flag4;
    // Start is called before the first frame update
    void Start()
    {
        flag1 = false;
        flag2 = false;
        flag3 = false;
        flag4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5 && flag1 == false)
        {
            timer = 0;
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            flag1 = true;
        }
        if (timer > 5 && flag2 == false)
        {
            timer = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
            flag2 = true;
        }
        if (timer > 5 && flag3 == false)
        {
            timer = 0;
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            flag3 = true;
        }
        if (timer > 5 && flag4 == false)
        {
            timer = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
            flag4 = true;
        }

    }
}
