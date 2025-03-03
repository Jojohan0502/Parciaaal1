using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoParaExplotar = 3f;
    public float radioExplosion = 5f;
    public float fuerzaExplosion = 700f;
    public GameObject efectoExplosion;
    public AudioClip sonidoExplosion;
    private AudioSource audioSource;
    public string tagObjetivo = "Destruible";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("Explotar", tiempoParaExplotar);
    }

    void Explotar()
    {
        if (efectoExplosion != null)
        {
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);
        }

        Collider[] objetosAfectados = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach (Collider objeto in objetosAfectados)
        {
            Rigidbody rb = objeto.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion, transform.position, radioExplosion);
            }

            if (objeto.CompareTag("Destruible"))
            {
                Destroy(objeto.gameObject);
            }
        }

        if (sonidoExplosion != null)
        {
            AudioSource.PlayClipAtPoint(sonidoExplosion, transform.position);
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        // La bomba solo explota si toca un objeto con el tag "Destruible"
        if (collision.gameObject.CompareTag("Destruible"))
        {
            Explotar();
        }
    }
}
