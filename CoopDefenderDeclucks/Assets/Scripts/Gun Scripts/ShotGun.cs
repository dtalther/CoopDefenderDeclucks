using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    // Start is called before the first frame update
    public override void Start()
    {
        //player = FindObjectOfType<PlayerController>();
        base.Start();
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void shoot(Vector3 dir)
    {
        print("Wee are in the shotgun shoot");
        if (player.isRapidFire)//Checks to see if rapid fire power up has been picked up
            currentFireRate = fireRate - 0.25f;
        else if (currentFireRate != fireRate)
            currentFireRate = fireRate;

        if (nextFire <= 0)
        {
            BulletCollision bulletObject = Instantiate(bulletType).GetComponent<BulletCollision>();
            BulletCollision bullet1 = Instantiate(bulletType).GetComponent<BulletCollision>();
            BulletCollision bullet2 = Instantiate(bulletType).GetComponent<BulletCollision>();
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
            adjustBullet(bullet1,new Vector3(0.2f,0,0));
            bullet1.transform.Rotate(0, 5, 0);

            adjustBullet(bullet2, new Vector3(-0.2f, 0, 0));
            bullet2.transform.Rotate(0, -5, 0);

            //bulletObject.rigid.velocity = transform.forward * bulletSpeed;
            //player.GetComponent<Rigidbody>().AddForce(new Vector3(0,10,-50), ForceMode.VelocityChange);
            nextFire = currentFireRate;
        }
    }

   
}
