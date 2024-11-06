using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeD : MonoBehaviour
{

    public GameObject[] characters; // Array para los personajes
    public int currentIndex = 0; // Índice del personaje actual
    private Vector3 NewPosition;

    // Start is called before the first frame update
    void Start()
    {
        

        // Asegúrate de que el array de personajes está inicializado y muestra solo el primero
        if (characters.Length > 0)
        {
           // ComponentsSwitch(true);
            
            ShowCharacter(currentIndex);
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //ComponentsSwitch(false);
            NewPosition = characters[currentIndex].transform.position;
            // Mostrar el siguiente personaje
            currentIndex = (currentIndex + 1) % characters.Length;
            ShowCharacter(currentIndex);
            //ComponentsSwitch(true);
            characters[currentIndex].GetComponent<Transform>().position = NewPosition;

        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //ComponentsSwitch(false);
            NewPosition = characters[currentIndex].transform.position;
            // Mostrar el personaje anterior
            currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
            ShowCharacter(currentIndex);
            //ComponentsSwitch(true);
            characters[currentIndex].GetComponent<Transform>().position = NewPosition;
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

    /*void ComponentsSwitch(bool verify)
    {
        characters[currentIndex].GetComponent<CharacterController>().enabled = verify;
        characters[currentIndex].GetComponent<Example>().enabled = verify;
    }*/
}