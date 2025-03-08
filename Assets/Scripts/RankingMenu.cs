using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankingMenu : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(BackToMenu);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}

