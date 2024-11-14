using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : ItemInteractive
{
    public string item;  // El ítem que contiene el cofre
    private bool isOpened = false;  // Si el cofre ya fue abierto

    // Sobrescribimos el método Interact para definir qué sucede cuando el jugador interactúa con el cofre
    public override void Interact()
    {
        if (!isOpened)
        {
            isOpened = true;
            Debug.Log("¡Cofre abierto! Has obtenido: " + item);
        }
        else
        {
            Debug.Log("El cofre ya está abierto.");
        }
    }
        /*public string item;  // El ítem que contiene el cofre
        private bool isOpened = false;  // Controla si ya fue abierto
        public bool CouldOpen = false;


        // Método público para abrir el cofre, será llamado desde el jugador
        public void OpenCofre()
        {
            if (!isOpened)
            {
                isOpened = true;
                Debug.Log("Se ha abierto el cofre, has obtenido: " + item);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CouldOpen = true;  // El jugador está dentro del colisionador, puede abrir el cofre
            }
        }

        // Método llamado cuando el jugador sale del área del cofre
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CouldOpen = false;  // El jugador ya no está dentro del colisionador
            }
        }*/
    }
