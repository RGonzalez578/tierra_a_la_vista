using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerdidaJugador : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisión de pérdida detectada");            
            GameManager.instancia.cambiarEscena("GameOver");
        }
    }
}
