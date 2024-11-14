using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impacto : MonoBehaviour
{
    public float fuerzaRetroceso = 10f;        // Fuerza del retroceso
    public float velocidadMaximaRetroceso = 5f; // Velocidad máxima del retroceso
    public float friccion = 0.2f;              // Fricción para reducir el retroceso con el tiempo
    public float gravedad = -9.8f;             // Gravedad aplicada en el retroceso
    private Vector3 velocidad = Vector3.zero;  // Velocidad del jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Impacto detectado con el jugador");

            // Obtener el CharacterController del jugador
            CharacterController characterController = other.GetComponent<CharacterController>();

            if (characterController != null)
            {
                // Calcular la dirección de retroceso
                Vector3 direccionRetroceso = (other.transform.position - transform.position).normalized;

                // Aplicar la fuerza de retroceso (similar a la física de un Rigidbody)
                velocidad += direccionRetroceso * fuerzaRetroceso;

                // Limitar la velocidad máxima
                if (velocidad.magnitude > velocidadMaximaRetroceso)
                {
                    velocidad = velocidad.normalized * velocidadMaximaRetroceso;
                }
            }
            else
            {
                Debug.LogWarning("El jugador no tiene un CharacterController.");
            }
        }
    }

    void Update()
    {
        // Obtener el CharacterController
        CharacterController characterController = GetComponent<CharacterController>();

        if (characterController != null)
        {
            // Aplicar la fricción (decremento de velocidad)
            velocidad *= (1 - friccion * Time.deltaTime);

            // Simular la gravedad
            velocidad.y += gravedad * Time.deltaTime;

            // Mover al jugador
            characterController.Move(velocidad * Time.deltaTime);
        }
    }
}