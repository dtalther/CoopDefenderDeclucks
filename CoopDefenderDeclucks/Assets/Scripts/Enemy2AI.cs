using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2AI : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent move;
    public float speed;
    public float dash;
    public float range;
    //Alerts enemies to the location of the player at all times
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        move = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        move.SetDestination(target.position);
        transform.LookAt(target);
        if (distance <= range)
        {
            transform.position += transform.forward * (speed + dash) * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
