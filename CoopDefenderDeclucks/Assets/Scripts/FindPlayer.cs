using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    #region Singleton
    public static FindPlayer found;
    void Awake()
    {
        found = this;
    }
    #endregion

    public GameObject player;
    private void Update()
    {
        player = player;
    }
}
