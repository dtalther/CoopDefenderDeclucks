using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy4AI : EnemyAI
{
    public Transform target;
    public NavMeshAgent move;
    public float speed;
    public float randomDirection;

    
    //Alerts enemies to the location of the player at all times
    private void Start()
    {
        randomDirection = Random.value;
        target = GameObject.FindObjectOfType<PlayerController>().transform;
        move = GetComponent<NavMeshAgent>();
        
        //move.stoppingDistance = 0f;
        //move.radius = .5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            move.SetDestination(target.position);
            move.speed = speed;
            
           transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (randomDirection % 2 == 0)
            {
                move.Move( transform.right * speed * Time.deltaTime);
            }
            else
            {
                move.Move(-transform.right * speed * Time.deltaTime);
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Death();
        }
        else if (collision.gameObject == target.gameObject)
        {
            Destroy(collision.gameObject);
        }
    }
   
}
