using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destino; // Punto al que se teletransportará el jugador

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que entra es el jugador
        {
            other.transform.position = destino.position; // Mueve al jugador al destino
        }
    }
}
