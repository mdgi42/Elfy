using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        MasterInfo.coinRoundCount += 1;
        MainMenuControl.coinCount += 1;
        PlayerPrefs.SetInt("Soldi", PlayerPrefs.GetInt("Soldi", 0) + 1);
        this.gameObject.SetActive(false);
    }

}
