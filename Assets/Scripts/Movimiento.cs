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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        velocidadOriginal = VelocidadPersonaje;
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

        // Movimiento lateral sin restricciones
        MoverLateral();
    }

    void MoverLateral()
    {
        float movimientoLateral = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movimientoLateral = -VelocidadIzqDer;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movimientoLateral = VelocidadIzqDer;
        }

        // Aplica el movimiento lateral
        transform.Translate(Vector3.right * movimientoLateral * Time.deltaTime, Space.World);
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
