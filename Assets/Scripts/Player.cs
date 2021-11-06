using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Private 
    private Vector3 posicionInicial;
    private float movimientoTransversal, movimientoLongitudinal, jump;
    private Rigidbody rigidBody;
    private Vector3 anguloRotacion;

    // Public
    public float velocidad = 1.5f;
    public float profundidadInicial = 1f;
    public float desplazamiento = 3f;
    public Vector3 desplazamientoCamara;
    public Camera mainCamera;

    private void FixedUpdate()
    {
        if (transform.position.y < 9)
        {
            float multiplicador = Mathf.Clamp01(transform.position.y / profundidadInicial) * desplazamiento;
            rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * multiplicador, 0f), ForceMode.Acceleration);
        }
    }

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    
    void Update()
    {
        movimientoTransversal = Input.GetAxis("Horizontal");
        movimientoLongitudinal = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        if (movimientoLongitudinal != 0 || movimientoTransversal != 0)
        {
            rigidBody.AddRelativeForce(Vector3.forward * -movimientoLongitudinal * velocidad);
            //transform.Translate(Vector3.back * movimientoLongitudinal * velocidad * Time.deltaTime);

            anguloRotacion = (new Vector3(0, movimientoTransversal, 0)) * velocidad;
            Quaternion deltaRotation = Quaternion.Euler(anguloRotacion * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }
        mainCamera.transform.position = (transform.position + desplazamientoCamara);
    }
}
