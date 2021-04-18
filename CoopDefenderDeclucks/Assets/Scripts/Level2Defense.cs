using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Defense : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CanvasObj;
    public GameObject explosion;
    public GameObject chicken;
    public GameObject endstate;

    private Level2_Text canvas;
    void Start()
    {
        canvas = CanvasObj.GetComponent<Level2_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            canvas.TextActivate(canvas.Update1_Txt.gameObject);
            StartCoroutine(Defense(canvas.Update1_Txt.gameObject));
        }
    }
    IEnumerator Defense(GameObject text)
    {
        print("Starting Defense!");
        yield return new WaitForSeconds(3f);
        canvas.TextDeactivate(text);
        print("Create Explosion");
        Instantiate(explosion,this.transform.position,this.transform.rotation);
        chicken.GetComponent<AllyAI>().canMove = true;
        canvas.TextUpdate_Timed(canvas.Update2_Txt.gameObject, 3f);
        Destroy(this.gameObject);
    }
}
