using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float contPowerUp = 0f;
    public int limitePowerUp = 10;
    public float ramdomX;
    public float ramdomZ;
    public GameObject powerUp;
    public Player player;
    public bool colisionDetectada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contPowerUp > limitePowerUp)
        {
            ramdomX = Random.Range((player.transform.position.x - 100), (player.transform.position.x + 100));
            ramdomZ = Random.Range((player.transform.position.z - 100), (player.transform.position.z + 100));

            var prefab = GameObject.Instantiate(powerUp, new Vector3(ramdomX, 11, ramdomZ), Quaternion.Euler(0, 0, 0));

            prefab.GetComponent<PowerUp>().setPowerUpManager(this);

            contPowerUp = 0f;

            //prefab.GetComponent<PowerUp>().quitarEscudo(escudo);

        }
        else
        {
            contPowerUp += Time.deltaTime;
        }

        if (colisionDetectada)
        {
            player.colisionado(colisionDetectada);
            colisionDetectada = false;
        }

    }

    public void colisionado(bool colision)
    {
        colisionDetectada = colision;
    }
}
