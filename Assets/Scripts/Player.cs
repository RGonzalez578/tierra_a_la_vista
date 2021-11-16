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
    private bool puertosHabilitados = true;

    // Public
    public float velocidad = 1.5f;
    public Vector3 desplazamientoCamara;
    public bool ocupaCamara = true;
    public Camera mainCamera;
    public float limiteSegundos = 59f;
    public float limiteMinutos = 5f;

    public Text lblTiempo;
    public Text txtMensajes;

    public Muelle[] muelles;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        for (int i = 0; i < muelles.Length; i++)
        {
            muelles[i].GetComponent<MeshRenderer>().enabled = false;
            muelles[i].GetComponent<CapsuleCollider>().enabled = false;
            GameObject muelle = muelles[i].transform.GetChild(0).gameObject;
            muelle.GetComponent<MeshRenderer>().enabled = false;
        }
        
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

            if (contadorSegundos <= 10f)
            {
                lblTiempo.text = contadorMinutos.ToString() + ":0" + Convert.ToInt32(contadorSegundos).ToString();
            }
            else
            {
                lblTiempo.text = contadorMinutos.ToString() + ":" + Convert.ToInt32(contadorSegundos).ToString();
            }
        }
        else if(puertosHabilitados)
        {
            puertosHabilitados = false;
            habilitarPuertos();            
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
        txtMensajes.text = "�Se ha habilitado un puerto!";

        int nMuelles = UnityEngine.Random.Range(0, 5);

        muelles[nMuelles].GetComponent<MeshRenderer>().enabled = true;
        muelles[nMuelles].GetComponent<CapsuleCollider>().enabled = true;
        GameObject muelle = muelles[nMuelles].transform.GetChild(0).gameObject;
        muelle.GetComponent<MeshRenderer>().enabled = true;
    }
}
