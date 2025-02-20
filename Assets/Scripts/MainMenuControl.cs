using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public static int coinCount;
    [SerializeField] GameObject coinDisplay;
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Soldi", 0);

    }

    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        PlayerPrefs.SetInt("Soldi", coinCount);

    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
