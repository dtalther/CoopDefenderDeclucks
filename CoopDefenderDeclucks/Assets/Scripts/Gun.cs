using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public float nextFire;
    public float bulletSpeed;
    public bool spread;
    public GameObject bulletType;
    // Start is called before the first frame update
    void Start()
    {
        //fireRate = 0.5f;
       // bulletSpeed = 20.0f;
       // nextFire = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
       
    }
    public void shoot(Vector3 dir)
    {
        if(nextFire <= 0)
        {
            BulletCollision bulletObject = Instantiate(bulletType).GetComponent<BulletCollision>();
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.rotation = transform.rotation;
            bulletObject.rigid.velocity = transform.forward * bulletSpeed;
            
            nextFire = fireRate;
        }
    }
}
