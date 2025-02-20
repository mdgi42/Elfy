using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

}
