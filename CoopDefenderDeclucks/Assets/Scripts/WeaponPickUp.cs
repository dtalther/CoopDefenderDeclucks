using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController var = collision.gameObject.GetComponent<PlayerController>();
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
        newGun.transform.position = var.gameObject.transform.position + var.gameObject.transform.forward;
        newGun.transform.rotation = new Quaternion(0,0,0,0);
    }
}
