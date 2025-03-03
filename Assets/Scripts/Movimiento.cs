using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    [Header("Cámara")]
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    private float xRotation = 0f;

    [Header("Respawn")]
    public Vector3 respawnPosition = new Vector3(0, 5, 0);
    public float fallThreshold = -10f;

    [Header("Disparo")]
    public GameObject bombaPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Mover();
        Saltar();
        VerificarCaida();
        RotarCamara();
        LanzarBomba();
    }

    void Mover()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        bool isMoving = moveX != 0 || moveZ != 0;
        animator.SetBool("IsMoving", isMoving);
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
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetBool("IsJumping", true);
        }
    }

    void VerificarCaida()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        rb.velocity = Vector3.zero;
    }

    void RotarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void LanzarBomba()
    {
        if (Input.GetKeyDown(KeyCode.E) && bombaPrefab != null && puntoDisparo != null)
        {
            GameObject bomba = Instantiate(bombaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rbBomba = bomba.GetComponent<Rigidbody>();

            if (rbBomba != null)
            {
                Vector3 direccionDisparo = transform.forward + Vector3.up * 0.5f; // Ajusta el ángulo para que tenga trayectoria parabólica
                rbBomba.velocity = direccionDisparo * fuerzaDisparo;
            }
        }
    }
}
