using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerdidaJugador : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisi�n de p�rdida detectada");            
            GameManager.instancia.cambiarEscena("GameOver");
        }
    }
}
