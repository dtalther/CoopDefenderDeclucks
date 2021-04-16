using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGrenade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }
}
