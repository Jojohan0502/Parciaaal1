using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string escenaGameOver = "RESUMEN"; // Nombre de la escena de Game Over

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo")) // Si toca un obst�culo
        {
            SceneManager.LoadScene(escenaGameOver); // Cambia de escena
        }
    }
}
