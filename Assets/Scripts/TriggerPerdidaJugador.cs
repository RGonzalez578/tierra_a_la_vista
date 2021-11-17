using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TriggerPerdidaJugador : MonoBehaviour
{

    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instancia.setPuntajeJugador(other.gameObject.GetComponent<Player>().calcularPuntaje(false));
            Debug.Log("Colisión de pérdida detectada");

            enemy.GetComponent<Enemy>().setDestruido(true);
            enemy.GetComponent<Floater>().setDestruido(true);
            enemy.GetComponent<BoxCollider>().enabled = false;

            other.gameObject.GetComponent<Player>().oro = 0;
            other.gameObject.GetComponent<Floater>().setDestruido(true);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
