using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light light;
    private float timer;
    private float amount;
    private bool intense;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        light = GetComponent<Light>();
        intense = false;
        amount = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedDeltaTime > 0 && intense == false)
        {
            timer += Time.deltaTime;
        }
        else if (Time.fixedDeltaTime > 0 && intense == true)
        {
            timer -= Time.deltaTime;
        }
        /*if(timer < 10 && intense == false)
        {
            light.intensity *= 2;
            intense = true;
            timer = 0;
        }
        else if(timer > 10 && intense == true)
        {
            intense = false;
            light.intensity/= 2;
            timer = 0;
        }*/
        if(timer < 3 && intense == false)
        {
            light.intensity += amount;
        }
        else if((timer > 3 || timer > 0) && intense == true)
        {
            light.intensity -= amount;
        }

        if(timer >= 3 && intense == false)
        {
            intense = true;
        }
        else if(timer <= 0 && intense == true)
        {
            intense = false;
        }

        
    }
}
