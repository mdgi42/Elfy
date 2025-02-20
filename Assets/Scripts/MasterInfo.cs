using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinRoundCount = 0;
    [SerializeField] GameObject coinDisplay;

    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinRoundCount;
    }
}

