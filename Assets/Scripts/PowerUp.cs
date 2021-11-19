using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{

    public GameObject escudoManager;
    
    

    public float contPowerUp = 0f;
    public int limitePowerUp = 10;
    public int tiempoActivo = 50;

    public bool estadoPowerUp = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            estadoPowerUp = true;
            escudoManager.SetActive(true);
            Debug.Log("Escudo esta activado");
           
            Destroy(this.gameObject);

        }
    }


    public void setEscudo(GameObject escudo) 
    {
        escudoManager = escudo;
    }

    public void setEscudoFalse(GameObject escudo)
    {
        escudoManager.SetActive(false);
        escudoManager = escudo;
    }

    public GameObject getEscudo() 
    {
        return escudoManager;
    }

    
}
