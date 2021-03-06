﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public AudioSource pickupSound;
    public Vector3 offset;//Offset to adjust gun properly

    void Start()
    {
        offset = new Vector3(0, .75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController var = collision.gameObject.GetComponent<PlayerController>();
        pickupSound.Play();
        if (var == null)
            return;
        if(var.gun != null)
        {
            Object.Destroy(var.gun.gameObject);
        }        
        GameObject newGun = Instantiate(obj);
        var.gun = newGun.GetComponent<Gun>();
        //obj.transform.position = var.transform.position;
        
        Object.Destroy(this.gameObject);
        newGun.transform.parent = var.gameObject.transform;
        newGun.transform.position = var.gameObject.transform.position + var.gameObject.transform.forward + offset;
        newGun.transform.rotation = new Quaternion(0,0,0,0);
        var.gun.fireRate *= var.fireRateMod;
        var.gun.bulletSpeed *= var.bulletSpeedMod;
    }
}
