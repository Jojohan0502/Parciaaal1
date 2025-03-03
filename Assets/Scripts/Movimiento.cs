using UnityEngine;

public class MovimientoPepsiman : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float desplazamientoCarril = 3f; // Distancia entre carriles
    private int carrilActual = 1; // 0 = Izquierda, 1 = Centro, 2 = Derecha
    private Vector3 objetivoPosicion;

    [Header("Salto")]
    public float fuerzaSalto = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        objetivoPosicion = transform.position;
    }

    void Update()
    {
        MoverAdelante();
        CambiarCarril();
        Saltar();
    }

    void MoverAdelante()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velocidad);
        animator.SetBool("IsMoving", true);
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

        // Calcular la posición objetivo en el carril correspondiente
        objetivoPosicion = new Vector3(carrilActual * desplazamientoCarril - desplazamientoCarril, transform.position.y, transform.position.z);

        // Mueve instantáneamente al personaje al nuevo carril
        transform.position = objetivoPosicion;
    }

    void Saltar()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, fuerzaSalto, rb.velocity.z);
            animator.SetBool("IsJumping", true);
        }
    }
}
