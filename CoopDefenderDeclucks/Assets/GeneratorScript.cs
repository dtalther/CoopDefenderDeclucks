using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    private Level3Manager manager;
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Level3Manager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!isColliding){
            if (collider.gameObject.tag.Equals("Bullet") && this.tag.Equals("Generator"))
            {
                isColliding = true;
                manager.checkGeneratorProgress();
                Instantiate(manager.Explosion, transform.position, transform.rotation).transform.localScale *= 3;
                Destroy(this.gameObject);
            }
            else if (collider.gameObject.tag.Equals("Bullet") && this.tag.Equals("PowerCore"))
            {
                isColliding = true;
                manager.checkPowerCoreProgress();
                Instantiate(manager.Explosion, transform.position, transform.rotation).transform.localScale *= 4;
                Destroy(this.gameObject);
            }
        }
    }
}
