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
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position +=  transform.forward * speed * Time.deltaTime;
    }
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "Bullet")
            Destroy(gameObject);
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
