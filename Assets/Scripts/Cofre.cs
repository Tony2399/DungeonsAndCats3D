using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public string item;  // El �tem que contiene el cofre
    private bool isOpened = false;  // Controla si ya fue abierto
    public bool CouldOpen = false;

    // M�todo p�blico para abrir el cofre, ser� llamado desde el jugador
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
            CouldOpen = true;  // El jugador est� dentro del colisionador, puede abrir el cofre
        }
    }

    // M�todo llamado cuando el jugador sale del �rea del cofre
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CouldOpen = false;  // El jugador ya no est� dentro del colisionador
        }
    }
}
