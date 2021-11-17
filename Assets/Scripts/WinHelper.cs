using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinHelper : MonoBehaviour
{

    public Text txt_puntaje;

    // Start is called before the first frame update
    void Start()
    {
        txt_puntaje.text = GameManager.instancia.getPuntajeJugador().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
