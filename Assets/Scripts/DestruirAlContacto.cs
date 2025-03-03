using UnityEngine;

public class Destruible : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomba"))
        {
            Destroy(gameObject);
        }
    }
}
