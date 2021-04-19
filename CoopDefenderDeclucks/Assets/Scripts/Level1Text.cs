using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Text : MonoBehaviour
{
    // Start is called before the first frame update
    public Text StartTxt;
    public Text EndTxt;
    public int count;
    
    void Start()
    {
        TextUpdate_Time(StartTxt.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 8)
            TextActivate(StartTxt.gameObject);
    }
    public void TextUpdate_Time(GameObject text, float time)
    {
        text.SetActive(true);
        StartCoroutine(RemoveText_Time(StartTxt.gameObject.gameObject, time));
    }
    public void TextActivate(GameObject text)
    {
        text.SetActive(true);
    }
    public void TextDeactivate(GameObject text)
    {
        text.SetActive(false);
    }

    IEnumerator RemoveText_Time(GameObject text, float time)
    {
        yield return new WaitForSeconds(time);
        print("Turn Off Text");
        text.SetActive(false);
    }
}
