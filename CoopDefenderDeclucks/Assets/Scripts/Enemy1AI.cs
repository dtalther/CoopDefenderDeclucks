using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1AI : EnemyAI
{

    public Transform target;
    public NavMeshAgent move;
    public float speed;
   
    //Alerts enemies to the location of the player at all times
    private void Awake()
    {
        target = GameObject.Find("Coop").transform;
        move = GetComponent<NavMeshAgent>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            move.SetDestination(target.position);
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Death();
        }
        else if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Coop"))
        {
            Destroy(collision.gameObject);
        }
    }

    
}
