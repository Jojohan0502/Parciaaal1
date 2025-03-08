using UnityEngine;

public class RecolectorObjetos : MonoBehaviour
{
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>(); // Busca el UIManager una vez al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))
        {
            int monedas = PlayerPrefs.GetInt("Monedas", 0) + 1;
            PlayerPrefs.SetInt("Monedas", monedas);
            PlayerPrefs.Save();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Barra"))
        {
            int barras = PlayerPrefs.GetInt("BarrasChocolate", 0) + 1;
            PlayerPrefs.SetInt("BarrasChocolate", barras);
            PlayerPrefs.Save();
            Destroy(other.gameObject);
        }

        if (uiManager != null)
        {
            uiManager.ActualizarUI();
        }
    }
}
