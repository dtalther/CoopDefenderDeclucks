using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2_Text : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Start_Txt;
    public Text Update1_Txt;
    public Text Update2_Txt;
    void Start()
    {
        TextUpdate_Timed(Start_Txt.gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TextUpdate_Timed(GameObject text, float time)
    {
        text.SetActive(true);
        StartCoroutine(RemoveText_Timed(Start_Txt.gameObject.gameObject, time ));
    }
    public void TextActivate(GameObject text)
    {
        text.SetActive(true);
    }
    public void TextDeactivate(GameObject text)
    {
        text.SetActive(false);
    }

    IEnumerator RemoveText_Timed(GameObject text, float time)
    {
        yield return new WaitForSeconds(time);
        print("Turn Off Text");
        text.SetActive(false);
    }
}
