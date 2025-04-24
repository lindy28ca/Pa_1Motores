using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.FlowStateWidget;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public int vida = 100;
    private Rigidbody rb;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!gameObject.activeSelf) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(h, 0, v) * velocidad * Time.deltaTime;
        rb.MovePosition(transform.position + movimiento);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            enSuelo = true;

        if (other.gameObject.CompareTag("Enemigo"))
        {
            vida -= 20;
            if (vida <= 0)
                GameManager.Instance.Perder();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            enSuelo = false;
    }
}

