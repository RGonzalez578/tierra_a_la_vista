using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject enemy;
    public Player player;
    public float contOleada = 0;
    public int cooldownSpawnEnemy = 30;
    public int nEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contOleada <= cooldownSpawnEnemy)
        {
            contOleada += Time.deltaTime;
        }
        else
        {
            int nCuadrante = Random.Range(1, 5);
            float posX = 0;
            float posZ = 0;

            switch (nCuadrante)
            {
                case 1:
                    posX = player.transform.position.x + Random.Range(100, 150);
                    posZ = player.transform.position.z + Random.Range(100, 150);
                    break;

                case 2:
                    posX = player.transform.position.x + Random.Range(100, 150);
                    posZ = player.transform.position.z + Random.Range(-150, -100);
                    break;

                case 3:
                    posX = player.transform.position.x + Random.Range(-150, -100);
                    posZ = player.transform.position.z + Random.Range(-150, -100);
                    break;

                case 4:
                    posX = player.transform.position.x + Random.Range(-150, -100);
                    posZ = player.transform.position.z + Random.Range(100, 150);
                    break;
            }

            var prefabEnemy = GameObject.Instantiate(enemy, new Vector3(posX, 50, posZ), Quaternion.Euler(0, 0, 0));
            prefabEnemy.GetComponent<Enemy>().setPlayer(player);
            nEnemies++;
            contOleada = 0;
        }
    }
}
