using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Referências")]
    public Transform orientation;    // Câmera/orientação
    public Animator animator;        // Animator do modelo 3D
    private Rigidbody rb;

    [Header("Movimentação")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public KeyCode runKey = KeyCode.LeftShift;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private float currentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Direção baseada na câmera
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0f;
        moveDirection.Normalize();

        // Corre ou anda?
        bool isMoving = moveDirection.magnitude > 0.1f;
        bool isRunning = Input.GetKey(runKey) && isMoving;
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Atualiza animação
        float animationSpeed = isMoving ? (isRunning ? 1f : 0.5f) : 0f;
        animator.SetFloat("Speed", animationSpeed); // 0 = idle, 0.5 = walk, 1 = run
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.fixedDeltaTime);
    }
}
