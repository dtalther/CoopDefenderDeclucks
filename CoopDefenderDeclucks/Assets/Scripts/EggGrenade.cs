using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGrenade : MonoBehaviour
{
    // Start is called before the first frame update
    public float lingerTime;
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<EnemyAI>().Death();
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lingerTime);
        if(gameObject != null)
            Destroy(gameObject);
    }
}
