using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private bool destruido;

    public Rigidbody rigidBody;
    public float profundidadInicial = 1f;
    public float desplazamiento = 3f;

    private void Start()
    {
        destruido = false;
    }

    private void FixedUpdate()
    {
        if (!destruido)
        {
            float altoOla = WaveManager.instancia.GetAltoOlaBarco(transform.position.x);
            if (transform.position.y < altoOla)
            {
                float multiplicador = Mathf.Clamp01((altoOla - transform.position.y) / profundidadInicial) * desplazamiento;
                rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * multiplicador, 0f), ForceMode.Acceleration);
            }
        }
        
    }
    public void setDestruido(bool value)
    {
        destruido = value;
    }
}
