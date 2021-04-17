using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2AI : EnemyAI
{
    public Transform target;
    public NavMeshAgent move;
    public float speed;
    public float dash;
    public float range;

   
    //Alerts enemies to the location of the player at all times
    private void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>().transform;
        move = GetComponent<NavMeshAgent>();
        move.stoppingDistance = 0f;
        move.radius = .5f;
        move.speed = speed;
       
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            move.SetDestination(target.position);
            //transform.LookAt(target);
            /*if (distance <= range)
            {
                transform.position += transform.forward * (speed + dash) * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }*/
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
    }
   
}
