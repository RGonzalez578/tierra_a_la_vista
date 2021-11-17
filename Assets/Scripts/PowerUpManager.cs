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


    public GameObject escudo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contPowerUp > limitePowerUp)
        {
            ramdomX = Random.Range((player.transform.position.x - 200), (player.transform.position.x + 200));
            ramdomZ = Random.Range((player.transform.position.z - 200), (player.transform.position.z + 200));

            var prefab = GameObject.Instantiate(powerUp, new Vector3(ramdomX, 11, ramdomZ), Quaternion.Euler(0, 0, 0));
            prefab.GetComponent<PowerUp>().setEscudo(escudo);

            contPowerUp = 0f;
        }
        else
        {
            contPowerUp += Time.deltaTime;
        }
    }
}
