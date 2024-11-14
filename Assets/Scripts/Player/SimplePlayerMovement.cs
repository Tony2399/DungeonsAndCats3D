using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.8f;  // Para gestionar la gravedad manualmente
    public float groundCheckDistance = 0.1f;  // Distancia para comprobar si está tocando el suelo

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();  // Obtener el CharacterController
    }

    void Update()
    {
        // Comprobar si el jugador está tocando el suelo usando el método isGrounded de CharacterController
        isGrounded = characterController.isGrounded;

        // Movimiento horizontal
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(x, 0, z);

        // Si el jugador está en el suelo, reducir la velocidad en Y para que no siga cayendo
        if (isGrounded)
        {
            velocity.y = -2f;  // Asegurarse de que el personaje se mantenga pegado al suelo cuando está en el suelo

            // Salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            // Si no está en el suelo, aplicar la gravedad
            velocity.y += gravity * Time.deltaTime;
        }

        // Mover el CharacterController, aplicando la velocidad calculada en X, Y, Z
        characterController.Move(movement * Time.deltaTime + velocity * Time.deltaTime);
    }

    void Jump()
    {
        // Asignamos la fuerza del salto al componente Y de la velocidad
        velocity.y = jumpForce;
    }
}