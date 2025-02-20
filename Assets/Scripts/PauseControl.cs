using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public GameObject titoloPausa;
    public GameObject bottoneResume;
    public GameObject bottoneQuit;
    public GameObject bottonePausa;
    [SerializeField] AudioSource music;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Replay()
    {
        //SceneManager.LoadScene(1);
        titoloPausa.SetActive(false);
        bottoneResume.SetActive(false);
        bottoneQuit.SetActive(false);
        bottonePausa.SetActive(true);
        Time.timeScale = 1f;
        music.Play();
    }

    public void Pause()
    {
        //SceneManager.LoadScene(0);
        titoloPausa.SetActive(true);
        bottoneResume.SetActive(true);
        bottoneQuit.SetActive(true);
        bottonePausa.SetActive(false);
        Time.timeScale = 0f;
        music.Pause();
    }

    public void QuitGame()
    {
        MasterInfo.coinRoundCount = 0;
        SceneManager.LoadScene(0);
    }
}
