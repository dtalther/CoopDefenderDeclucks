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
    private void Start()
    {
        target = GameObject.Find("Coop").transform;
       // target = GameObject.FindObjectOfType<PlayerController>().transform;
        move = GetComponent<NavMeshAgent>();
        move.speed = speed;

    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            move.SetDestination(target.position);
            //transform.LookAt(target);
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        if (collision.gameObject.tag.Equals("Coop"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    
}
