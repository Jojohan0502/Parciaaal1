using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text nombreJugador;
    public Text monedasTexto;
    public Text barrasTexto;

    void Start()
    {
        nombreJugador.text = "Jugador: " + PlayerPrefs.GetString("NombreUsuario", "Invitado");
        ActualizarUI(); //  Llamamos para actualizar la interfaz desde el inicio
    }

    public void ActualizarUI()
    {
        monedasTexto.text = "Monedas: " + PlayerPrefs.GetInt("Monedas", 0);
        barrasTexto.text = "Barras: " + PlayerPrefs.GetInt("BarrasChocolate", 0);
    }
}
