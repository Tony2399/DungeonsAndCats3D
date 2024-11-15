using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    public float groundCheckRadius = 0.2f;  // Radio de la esfera para verificar suelo
    public Transform groundCheck;  // Objeto para marcar el punto de verificación de suelo

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Evita rotaciones no deseadas
    }

    void Update()
    {
        // Verificar si el personaje está en el suelo con una esfera de colisión
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius);

        // Llamar a la función de movimiento
        Move();

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        // Obtener el input para el movimiento horizontal y vertical
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Crear un vector de dirección basado en el input
        Vector3 direction = new Vector3(x, 0, z).normalized;

        // Mover el Rigidbody en la dirección deseada multiplicada por la velocidad
        Vector3 movement = direction * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void Jump()
    {
        // Aplicar una fuerza hacia arriba para el salto
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}