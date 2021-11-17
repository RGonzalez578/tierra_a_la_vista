using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{

    
    public GameObject escudo;
    

    public float contPowerUp = 0f;
    public int limitePowerUp = 10;

    public bool estadoPowerUp = false;
   

    // Start is called before the first frame update
    void Start()
    {
        //timer = gameObject.GetComponent<PowerUp>();
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
                escudo.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //var player = other.GetComponent<Player>();
            //var escudo = player.transform.GetChild(25).gameObject;
            escudo.SetActive(true);
            estadoPowerUp = true;
        }
    }

    public void controladorPowerUp(bool estadoPowerUp) 
    {
        if (estadoPowerUp == true)
        { 
            
        }
    }

    
}
