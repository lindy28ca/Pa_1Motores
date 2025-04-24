using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugadores : MonoBehaviour
{
    public GameObject[] jugadores;
    private int indiceActual = 0;

    void Start()
    {
        ActivarJugador(indiceActual);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            indiceActual = (indiceActual - 1 + jugadores.Length) % jugadores.Length;
            ActivarJugador(indiceActual);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            indiceActual = (indiceActual + 1) % jugadores.Length;
            ActivarJugador(indiceActual);
        }
    }

    void ActivarJugador(int indice)
    {
        for (int i = 0; i < jugadores.Length; i++)
        {
            jugadores[i].SetActive(i == indice);
        }
    }
}

