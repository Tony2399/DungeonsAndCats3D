using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeD : MonoBehaviour
{

    public GameObject[] characters; // Array para los personajes
    private int currentIndex = 0; // Índice del personaje actual

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el array de personajes está inicializado y muestra solo el primero
        if (characters.Length > 0)
        {
            ShowCharacter(currentIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Mostrar el siguiente personaje
            currentIndex = (currentIndex + 1) % characters.Length;
            ShowCharacter(currentIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // Mostrar el personaje anterior
            currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
            ShowCharacter(currentIndex);
        }
    }

    void ShowCharacter(int index)
    {
        // Oculta todos los personajes
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        // Muestra el personaje seleccionado
        if (characters.Length > 0)
        {
            characters[index].SetActive(true);
        }
    }
}