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

    // Public
    public float velocidad = 1.5f;
    public Vector3 desplazamientoCamara;
    public bool ocupaCamara = true;
    public Camera mainCamera;
    //public float tiempoTranscurrido = 0f;
    public float tiempoRestante;

    public Text lblTiempo;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    
    void Update()
    {
        //tiempoTranscurrido += Time.deltaTime;

        if (contadorMinutos < 5)
        {
            contadorSegundos += Time.deltaTime;

            if (contadorSegundos >= 59f)
            {
                contadorSegundos = 0f;
                contadorMinutos++;
            }

            lblTiempo.text = contadorMinutos.ToString() + ":" + Convert.ToInt32(contadorSegundos).ToString();
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
}
