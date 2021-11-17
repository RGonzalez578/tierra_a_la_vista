using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municionManager : MonoBehaviour
{
    public float randomX;
    public float randomZ;
    public GameObject itemMunicion;
    //public bool instanciarMunicion = false;
    public float contSegundos = 0f;
    public int cooldownSpawn = 15;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (contSegundos >= cooldownSpawn)
        {
            randomX = Random.Range((player.transform.position.x - 100) + 20, (player.transform.position.x + 100) - 20);
            randomZ = Random.Range((player.transform.position.z - 100) + 20, (player.transform.position.z + 100) - 20);

            var prefab = GameObject.Instantiate(itemMunicion, new Vector3(randomX, 11, randomZ), Quaternion.Euler(0, 0, 0));
            //Debug.Log("Munición creada en: " + prefab.transform.position);
            contSegundos = 0f;
        }
        else
        {
            contSegundos += Time.deltaTime;
        }
        
    }
}
