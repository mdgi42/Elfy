using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{     

    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnim;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeOut;
    public GameObject[] personaggi;
    private int personaggioCorrente;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        personaggioCorrente = PlayerPrefs.GetInt("Personaggio", 0);
        collisionFX.Play();
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        //playerAnim.GetComponent<Animator>().Play("Stumble Backwards");
        personaggi[personaggioCorrente].GetComponent<Animator>().Play("Stumble Backwards");
        mainCam.GetComponent<Animator>().Play("CollisionCam");
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene(0);
        MasterInfo.coinRoundCount = 0;
        SceneManager.LoadScene(2);
    }


}
