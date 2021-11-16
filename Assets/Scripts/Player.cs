using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Private 
    private Vector3 posicionInicial;
    private float movimientoTransversal, movimientoLongitudinal;
    private Rigidbody rigidBody;
    private Vector3 anguloRotacion;
    private float contadorSegundos = 0;
    private float contadorMinutos = 0;
    private int oro = 50;

    // Public
    public float velocidad = 1.5f;
    public Vector3 desplazamientoCamara;
    public bool ocupaCamara = true;
    public Camera mainCamera;
    public float limiteSegundos = 59f;
    public float limiteMinutos = 5f;

    public Text lblOro;
    public Text lblTiempo;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        lblOro.text = oro.ToString();
    }

    
    void Update()
    {
        //tiempoTranscurrido += Time.deltaTime;

        if (contadorMinutos < limiteMinutos)
        {
            contadorSegundos += Time.deltaTime;

            if (contadorSegundos >= limiteSegundos)
            {
                contadorSegundos = 0f;
                contadorMinutos++;
            }

            int contadorSeg = Convert.ToInt32(contadorSegundos);

            if (contadorSeg < 10)
            {
                lblTiempo.text = contadorMinutos.ToString() + ":0" + contadorSeg.ToString();
            }
            else
            {
                lblTiempo.text = contadorMinutos.ToString() + ":" + contadorSeg.ToString();
            }
        }
        else
        {
            habilitarPuertos();
        }

        if (oro <= 0)
        {
            GameManager.instancia.cambiarEscena("GameOver");
        }

        movimientoTransversal = Input.GetAxis("Horizontal");
        movimientoLongitudinal = Input.GetAxis("Vertical");

        if (movimientoLongitudinal != 0 || movimientoTransversal != 0)
        {
            rigidBody.AddRelativeForce(Vector3.forward * -movimientoLongitudinal * velocidad);

            anguloRotacion = (new Vector3(0, movimientoTransversal, 0)) * velocidad;
            Quaternion deltaRotation = Quaternion.Euler(anguloRotacion * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
        if (ocupaCamara)
        {
            mainCamera.transform.position = (transform.position + desplazamientoCamara);
        }
        
    }

    public void habilitarPuertos()
    {
        //float random = Random.Range(0,4);
    }

    public int getOro()
    {
        return this.oro;
    }

    public void restarOro(int oroEliminado)
    {
        oro = oro - oroEliminado;
        lblOro.text = oro.ToString();
    }

    public void sumarOro(int oroEliminado)
    {
        oro = oro + oroEliminado;
        lblOro.text = oro.ToString();
    }
}
