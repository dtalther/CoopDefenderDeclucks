using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    private float currentFireRate;
    public float nextFire;
    public float bulletSpeed;
    public ParticleSystem muzzleFlash;
    public bool spread;
    public GameObject bulletType;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //fireRate = 0.5f;
        // bulletSpeed = 20.0f;
        // nextFire = -1;
        player = FindObjectOfType<PlayerController>();
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
        if (player.isRapidFire)//Checks to see if rapid fire power up has been picked up
            currentFireRate = fireRate - 0.25f;
        else if (currentFireRate != fireRate)
            currentFireRate = fireRate;

        if (nextFire <= 0)
        {
            BulletCollision bulletObject = Instantiate(bulletType).GetComponent<BulletCollision>();
            muzzleFlash.Play();

            if (player.isSpregg)
            {
                BulletCollision shot1 = Instantiate(bulletType).GetComponent<BulletCollision>();
                BulletCollision shot2 = Instantiate(bulletType).GetComponent<BulletCollision>();

                adjustBullet(shot1, -transform.right);
                shot1.transform.Rotate(0, -25, 0);
               // shot1.rigid.velocity = ((transform.forward - transform.right)/2).normalized * bulletSpeed;

                adjustBullet(shot2, transform.right);
                shot2.transform.Rotate(0, 25, 0);
                //shot2.rigid.velocity = ((transform.forward + transform.right)/2).normalized * bulletSpeed;
            }


            adjustBullet(bulletObject, Vector3.zero);
            //bulletObject.rigid.velocity = transform.forward * bulletSpeed;

            nextFire = currentFireRate;
        }
    }

    //Adjusts the bullets position, rotation, and velocity properly
    public void adjustBullet(BulletCollision bullet, Vector3 trajectory)
    {
        bullet.transform.position = transform.position + transform.forward;
        bullet.transform.rotation = transform.rotation;
        bullet.rigid.velocity = ((transform.forward + trajectory) / 2).normalized * bulletSpeed;

    }
}
