using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{

    private GameObject escudoManager;
    

    public float contPowerUp = 0f;
    public int limitePowerUp = 10;
    public int tiempoActivo = 45;

    public bool estadoPowerUp = false;
   

    // Start is called before the first frame update
    void Start()
    {
        //timer = gameObject.GetComponent<PowerUp>();
        //escudoManager = FindObjectOfType<EscudoManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (estadoPowerUp)
        {
            if (contPowerUp <= limitePowerUp)
            {
                contPowerUp += Time.deltaTime;
            }
            else 
            {
                contPowerUp = 0f;
                escudoManager.SetActive(false);
                estadoPowerUp = false;
            }

        }
        Destroy(this.gameObject, tiempoActivo);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //var player = other.GetComponent<Player>();
            //var escudo = player.transform.GetChild(25).gameObject;
            escudoManager.SetActive(true);
            estadoPowerUp = true;
            Destroy(this.gameObject);
        }
    }


    public void setEscudo(GameObject escudo) 
    {
        escudoManager = escudo;
    }

    public GameObject getEscudo() 
    {
        return escudoManager;
    }
}
