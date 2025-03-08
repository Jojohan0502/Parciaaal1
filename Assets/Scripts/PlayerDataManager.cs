using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public TMP_InputField nameInput; // Input field para el nombre
    public TMP_InputField emailInput; // Input field para el correo
    public Button playButton; // Botón para iniciar el juego

    void Start()
    {
        playButton.onClick.AddListener(SavePlayerData);
    }

    void SavePlayerData()
    {
        string playerName = nameInput.text;
        string playerEmail = emailInput.text;

        if (IsValidEmail(playerEmail) && !string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.SetString("PlayerEmail", playerEmail);
            PlayerPrefs.Save();

            Debug.Log("Datos guardados: " + playerName + " - " + playerEmail);

            // Cargar la escena del juego (ajusta el nombre según tu configuración)
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.LogError("Nombre o correo inválido. Inténtalo de nuevo.");
        }
    }

    bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}
