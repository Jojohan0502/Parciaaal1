using UnityEngine;

public class ActivarPuente : MonoBehaviour
{
    public GameObject puente; 

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo ha entrado en el trigger: " + other.gameObject.name);

        if (other.CompareTag("Bomba")) 
        {
            Debug.Log("¡La bomba ha activado el puente!");

            if (puente != null)
            {
                Rigidbody rbPuente = puente.GetComponent<Rigidbody>();
                if (rbPuente != null)
                {
                    rbPuente.isKinematic = false; 
                    Debug.Log("¡Puente activado!");
                }
                else
                {
                    Debug.LogError("¡El puente no tiene un Rigidbody!");
                }
            }
            else
            {
                Debug.LogError("¡No has asignado un puente en el Inspector!");
            }

            Destroy(gameObject); 
        }
    }
}
