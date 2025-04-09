using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Transform orientation; // Refer�ncia � orienta��o da c�mera
    private Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 6f;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita girar com f�sica
    }

    private void Update()
    {
        // Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Dire��o baseada na orienta��o da c�mera
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0f; // Garante que o personagem n�o tente se mover para cima/baixo
        moveDirection.Normalize();
    }

    private void FixedUpdate()
    {
        // Movimento
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
