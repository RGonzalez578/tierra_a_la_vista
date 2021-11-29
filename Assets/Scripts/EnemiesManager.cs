using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    public GameObject enemy;
    public Player player;
    public float contOleada = 0;
    public int cooldownSpawnEnemy = 30;
    public int nEnemies;
    public float contMostrarMensaje = 0f;
    public int cooldownMensaje = 5;
    public string msgOleadaActiva = "OLEADA_1_ACTIVA";

    public GameObject[] spawns;
    public Text txtMensajes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (mensajeEncendido)
        {
            if (contMostrarMensaje <= cooldownMensaje)
            {
                contMostrarMensaje += Time.deltaTime;
                txtMensajes.text = "Aparecerán 4 enemigos pronto";
                mensajeEncendido = true;
            }
            else
            {
                contMostrarMensaje = 0f;
                mensajeEncendido = false;
                txtMensajes.text = "";
            }
        }*/

        if (player.getMinutos() < 1)
        {
            cooldownSpawnEnemy = 15;

            if (contMostrarMensaje <= cooldownMensaje && msgOleadaActiva.Equals("OLEADA_1_ACTIVA"))
            {
                contMostrarMensaje += Time.deltaTime;
                txtMensajes.text = "Aparecerán 4 enemigos pronto";
                //mensajeEncendido = true;
            }
            else
            {
                contMostrarMensaje = 0f;
                //mensajeEncendido = true;
                txtMensajes.text = "";
                msgOleadaActiva = "OLEADA_2_ACTIVA";
            }

        } 
        else if (player.getMinutos() < 2)
        {
            cooldownSpawnEnemy = 10;

            if (contMostrarMensaje <= cooldownMensaje && msgOleadaActiva.Equals("OLEADA_2_ACTIVA"))
            {
                contMostrarMensaje += Time.deltaTime;
                txtMensajes.text = "Aparecerán 6 enemigos pronto";
                //mensajeEncendido = true;
            }
            else
            {
                contMostrarMensaje = 0f;
                //mensajeEncendido = true;
                txtMensajes.text = "";
                msgOleadaActiva = "OLEADA_3_ACTIVA";
            }
        }
        else
        {
            cooldownSpawnEnemy = 5;

            if (contMostrarMensaje <= cooldownMensaje && msgOleadaActiva.Equals("OLEADA_3_ACTIVA"))
            {
                contMostrarMensaje += Time.deltaTime;
                txtMensajes.text = "Aparecerán 12 enemigos pronto";
            }
            else
            {
                contMostrarMensaje = 0f;
                txtMensajes.text = "";
                msgOleadaActiva = "FIN_OLEADAS";
            }
        }

        if (player.getMinutos() != 3)
        {
            if (contOleada <= cooldownSpawnEnemy)
            {
                contOleada += Time.deltaTime;
            }
            else
            {

                int nSpawn = Random.Range(0, spawns.Length);
                Vector3 vectorSpawn = new Vector3(spawns[nSpawn].transform.position.x + Random.Range(-20, 20), 9, spawns[nSpawn].transform.position.z + Random.Range(-20, 20));

                var prefabEnemy = GameObject.Instantiate(enemy, vectorSpawn, Quaternion.Euler(0, Random.Range(0, 360), 0));
                prefabEnemy.GetComponent<Enemy>().setPlayer(player);
                nEnemies++;
                contOleada = 0;
            }
        }

    }
}
