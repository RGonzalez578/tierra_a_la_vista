using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerdidaJugador : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instancia.setPuntajeJugador(other.gameObject.GetComponent<Player>().calcularPuntaje(false));
            Debug.Log("Colisión de pérdida detectada");            
            GameManager.instancia.cambiarEscena("GameOver");
        }
    }
}
