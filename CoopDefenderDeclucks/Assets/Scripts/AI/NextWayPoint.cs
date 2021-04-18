using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWayPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform nextPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We in there");
        AllyAI var = other.gameObject.GetComponent<AllyAI>();
        if (other.gameObject.GetComponent<AllyAI>() != null)
        {
            var.target = nextPoint;
            Destroy(this.gameObject);
        }
    }
}
