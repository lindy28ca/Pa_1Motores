using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    void Awake()
    {
        Instance = this;
    }

    public void Ganar()
    {
        panelVictoria.SetActive(true);
        Time.timeScale = 0;
    }

    public void Perder()
    {
        panelDerrota.SetActive(true);
        Time.timeScale = 0;
    }
}

