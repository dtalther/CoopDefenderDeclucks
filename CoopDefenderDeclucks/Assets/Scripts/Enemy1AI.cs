using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1AI : MonoBehaviour
{

    public Transform target;
    public NavMeshAgent move;
    public float speed;
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
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(target);
    }
}
