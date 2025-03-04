using UnityEngine;
using UnityEngine.UI; // Necesario para manejar UI

public class RecolectarObjetos : MonoBehaviour
{
    public int contadorObjetos = 0; // Contador de objetos recolectados
    public Text contadorTexto; // Referencia al texto de UI (opcional)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda")) // Si toca un objeto recolectable
        {
            contadorObjetos++; // Aumenta el contador
            Destroy(other.gameObject); // Destruye el objeto recolectado

            // Actualiza el texto en pantalla (si hay un UI Text asignado)
            if (contadorTexto != null)
            {
                contadorTexto.text = "Objetos: " + contadorObjetos;
            }
        }
    }
}
