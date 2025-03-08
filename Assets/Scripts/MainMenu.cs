using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button rankingButton;
    public Button exitButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        rankingButton.onClick.AddListener(ShowRanking);
        exitButton.onClick.AddListener(ExitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("GAME");
    }

    void ShowRanking()
    {
        SceneManager.LoadScene("RESUMEN");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
