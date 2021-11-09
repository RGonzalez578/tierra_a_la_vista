using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float profundidadInicial = 1f;
    public float desplazamiento = 3f;
    //public float aguaDrag = 0.99f;
    //public float aguaAngularDrag = 0.5f;
    //public int floaterCount = 1;

    private void FixedUpdate()
    {
        //rigidBody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float altoOla = WaveManager.instancia.GetAltoOlaBarco(transform.position.x);
        if (transform.position.y < altoOla)
        {
            float multiplicador = Mathf.Clamp01((altoOla - transform.position.y) / profundidadInicial) * desplazamiento;
            //rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * multiplicador, 0f), transform.position, ForceMode.Acceleration);
            //rigidBody.AddForce(multiplicador * -rigidBody.velocity * aguaDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            //rigidBody.AddTorque(multiplicador * -rigidBody.angularVelocity * aguaAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * multiplicador, 0f), ForceMode.Acceleration);
        }
    }
}
