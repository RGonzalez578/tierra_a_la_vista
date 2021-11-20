using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public int tiempoActivo = 20;
    public bool estadoPowerUp = false;
    public PowerUpManager powerUpManager;
   

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(this.gameObject, tiempoActivo);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            powerUpManager.colisionado(true);
            Debug.Log("Escudo esta activado");
           
            Destroy(this.gameObject);

        }
    }

    public void setPowerUpManager(PowerUpManager powerUpManager)
    {
        this.powerUpManager = powerUpManager;
    }

}
