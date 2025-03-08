using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;

    void Start()
    {
        // (Opcional) Mostrar el nombre del jugador en la UI si lo necesitas
        Debug.Log("Jugador: " + PlayerPrefs.GetString("PlayerName", "Invitado"));
    }

    public void AddScore(int points)
    {
        playerScore += points;
    }

    public void GameOver()
    {
        // Obtener nombre del jugador
        string playerName = PlayerPrefs.GetString("PlayerName", "Invitado");

        // Guardar el puntaje en PlayerPrefs
        SaveScore(playerName, playerScore);

        // Cargar la escena del ranking
        SceneManager.LoadScene("RankingScene");
    }

    void SaveScore(string name, int score)
    {
        // Guardar el nuevo puntaje en una lista junto con los anteriores
        string allScores = PlayerPrefs.GetString("AllScores", ""); // Recuperar datos previos
        allScores += name + ":" + score + ";"; // Agregar nuevo puntaje
        PlayerPrefs.SetString("AllScores", allScores); // Guardar lista actualizada
        PlayerPrefs.Save();
    }
}
