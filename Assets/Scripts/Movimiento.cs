using System.Collections;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    [Header("Velocidades")]
    public float VelocidadPersonaje = 3.0f;
    public float VelocidadIzqDer = 4.0f;
    public float FuerzaSalto = 5.0f;

    private bool enSuelo = true;
    private Rigidbody rb;
    private Animator anim;

    private float velocidadOriginal;
    private int carrilActual = 1; // 0 = Izquierda, 1 = Centro, 2 = Derecha
    private float distanciaCarril = 2.0f; // Distancia entre carriles
    private Vector3 objetivoPosicion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        velocidadOriginal = VelocidadPersonaje;
        objetivoPosicion = transform.position;
    }

    void Update()
    {
        // Movimiento hacia adelante
        transform.Translate(Vector3.forward * Time.deltaTime * VelocidadPersonaje, Space.World);

        // Animación de movimiento
        if (enSuelo)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsMoving", true);
        }

        // Animación de salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * FuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
            anim.SetBool("IsJumping", true);
        }

        // Cambio de carril
        CambiarCarril();
    }

    void CambiarCarril()
    {
        if (Input.GetKeyDown(KeyCode.A) && carrilActual > 0)
        {
            carrilActual--; // Mueve a la izquierda
        }
        else if (Input.GetKeyDown(KeyCode.D) && carrilActual < 2)
        {
            carrilActual++; // Mueve a la derecha
        }

        // Calcula la nueva posición en el carril correspondiente
        objetivoPosicion = new Vector3((carrilActual - 1) * distanciaCarril, transform.position.y, transform.position.z);

        // Movimiento suave
        transform.position = Vector3.Lerp(transform.position, objetivoPosicion, Time.deltaTime * VelocidadIzqDer);
    }

    public void AumentarVelocidad(float aumento, float duracion)
    {
        VelocidadPersonaje += aumento;
        StartCoroutine(RestablecerVelocidad(duracion));
    }

    private IEnumerator RestablecerVelocidad(float duracion)
    {
        yield return new WaitForSeconds(duracion);
        VelocidadPersonaje = velocidadOriginal;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
