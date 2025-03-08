using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestorUsuario : MonoBehaviour
{
    public InputField inputNombre;
    public Text nombreMostrado;

    void Start()
    {
        if (PlayerPrefs.HasKey("NombreUsuario"))
        {
            string nombre = PlayerPrefs.GetString("NombreUsuario");
            nombreMostrado.text = "Jugador: " + nombre;
        }
    }

    public void GuardarNombre()
    {
        PlayerPrefs.SetString("NombreUsuario", inputNombre.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Juego"); // Cambia a la escena del juego
    }
}