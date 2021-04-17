using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy4AI : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent move;
    public float speed;
    public float randomDirection;
    //Alerts enemies to the location of the player at all times
    private void Awake()
    {
        randomDirection = Random.value;
        target = GameObject.Find("Player").transform;
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
            if (randomDirection % 2 == 0)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += -transform.right * speed * Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
