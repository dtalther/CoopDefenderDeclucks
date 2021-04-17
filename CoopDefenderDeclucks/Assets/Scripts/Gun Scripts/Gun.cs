using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;//Rate of fire for the gun
    protected float currentFireRate;
    public float nextFire;//Checks if the gun can fire
    public float bulletSpeed; // speed at which the bullet travels
    public ParticleSystem muzzleFlash; // The particle system for the muzzle flash
    public bool spread;
    public GameObject bulletType;//Type of bullet
    public AudioSource ShootSound;//sound effect for gun shot
    public PlayerController player;//Player reference

    // Start is called before the first frame update
   public virtual void Start()
    {
        //fireRate = 0.5f;
        // bulletSpeed = 20.0f;
        // nextFire = -1;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }

    }
    public virtual void shoot(Vector3 dir)
    {
        print("Wee are in the default shoot");
        if (player.isRapidFire)//Checks to see if rapid fire power up has been picked up
            currentFireRate = fireRate * 0.8f;
        else if (currentFireRate != fireRate)
            currentFireRate = fireRate;

        if (nextFire <= 0)
        {
            BulletCollision bulletObject = Instantiate(bulletType).GetComponent<BulletCollision>();
            muzzleFlash.Play();
            ShootSound.Play();

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
