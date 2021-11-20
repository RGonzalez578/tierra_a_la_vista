using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class municion : MonoBehaviour
{
    private Vector3 anguloRotacion;
    private Quaternion deltaRotation;
    private Rigidbody rb;

    public int municionAdquirida = 10;
    public int velocidadRotacion = 30;
    public int tiempoActivo = 45;

    // Start is called before the first frame update
    void Start()
    {
        anguloRotacion = (Vector3.up) * velocidadRotacion;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaRotation = Quaternion.Euler(anguloRotacion * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        Destroy(this.gameObject, tiempoActivo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();

            player.sumarMunicion(municionAdquirida);

            Destroy(this.gameObject);
        }
    }
}
