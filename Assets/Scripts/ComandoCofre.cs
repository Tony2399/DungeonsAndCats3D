using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandoCofre : MonoBehaviour
{
    public Cofre chestInRange;  // Referencia al cofre en el que está el jugador

    

    // En el Update revisamos si el jugador está dentro del área del cofre y si presiona la tecla
    private void Update()
    {

        
        // Verificamos si hay un cofre en rango y si el jugador puede abrirlo (CouldOpen == true)
        if (Input.GetKeyDown(KeyCode.F))  // Cambia KeyCode.E por la tecla que prefieras
        {
            if (chestInRange.CouldOpen == true)
            {
                chestInRange.OpenCofre();
            }
        }
    }
}
