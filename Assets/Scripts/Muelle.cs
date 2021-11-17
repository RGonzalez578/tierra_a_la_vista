using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Muelle : MonoBehaviour
{
    public float contador = 0f;
    public Text txt_ganarPartida;
    public float tiempoLimite = 3f;

    private void Start()
    {
        txt_ganarPartida.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        if (contador < tiempoLimite)
        {
            contador += Time.deltaTime;
            int tiempo = Convert.ToInt32(tiempoLimite - contador);
            txt_ganarPartida.text = "Fin de la Partida en.. " + tiempo.ToString();
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instancia.setPuntajeJugador(other.gameObject.GetComponent<Player>().calcularPuntaje(true));
                ganarPartida();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        txt_ganarPartida.text = "";
        contador = 0;
    }

    public void ganarPartida()
    {
        GameManager.instancia.cambiarEscena("Win");
    }
}
