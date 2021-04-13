using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3AI : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent move;
    public float speed;
    public float changeDirection;
    //Alerts enemies to the location of the player at all times
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        move = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        move.SetDestination(target.position);
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
        if(changeDirection < 0 || changeDirection > 250)
        {
            changeDirection = 0;
        }
        if(changeDirection <= 125)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            changeDirection += 1;
        }
        else if(changeDirection <= 250)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            changeDirection += 1;
        }
    }
}
