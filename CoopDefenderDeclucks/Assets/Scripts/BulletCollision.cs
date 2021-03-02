using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float speed;
    public Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position +=  transform.forward * speed * Time.deltaTime;
    }
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
