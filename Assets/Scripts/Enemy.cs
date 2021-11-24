using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Private
    private Rigidbody rigidBody;
    private Vector3 anguloRotacion;
    private bool destruido;
    private float fuerzaMunicion = 20f;
    private float cooldown = 0;

    //Public 
    public float velocidad = 1.5f;
    public Vector3 playerPosition;
    public Vector3 enemyPosition;
    public Player player;
    public GameObject municionEnemy;
    public GameObject containerMunicionAdelante;
    public GameObject containerMunicionIzq;
    public GameObject containerMunicionDer;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        destruido = false;
    }

    
    void Update()
    {
        if (!destruido)
        {
            playerPosition = player.transform.position;
            enemyPosition = transform.position;

            if (Vector3.Distance(enemyPosition, playerPosition) < 100)
            {
                Vector3 vector = new Vector3(0, 0, Random.Range(-10, 10));
                transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, velocidad * Time.deltaTime);
                //transform.forward = (playerPosition - transform.position) + vector;
                transform.forward = playerPosition - transform.position;

                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }
                if (cooldown <= 0)
                {
                    disparar();
                    cooldown = 5;
                }
            }

            /*float x = playerPosition.x;
            float z = playerPosition.z;

            float angulo = 0f;
            if ((playerPosition.x - enemyPosition.x) > 0 && (playerPosition.z - enemyPosition.z) < 0)
            {
                angulo = -1;
            }
            if ((playerPosition.x - enemyPosition.x) > 0 && (playerPosition.z - enemyPosition.z) > 0)
            {
                angulo = -1;
            }
            if ((playerPosition.x - enemyPosition.x) < 0 && (playerPosition.z - enemyPosition.z) < 0)
            {
                angulo = 1;
            }
            if ((playerPosition.x - enemyPosition.x) < 0 && (playerPosition.z - enemyPosition.z) > 0)
            {
                angulo = 1;
            }
            anguloRotacion = (new Vector3(0, angulo, 0)) * velocidad;
            Quaternion deltaRotation = Quaternion.Euler(anguloRotacion * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);


            rigidBody.AddRelativeForce(Vector3.forward * -1 * (velocidad / 2));*/
        }
        else
        {
            rigidBody.constraints = RigidbodyConstraints.None;

            anguloRotacion = (new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1))) * velocidad;
            Quaternion deltaRotation = Quaternion.Euler(anguloRotacion * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }

    }

    public void setDestruido(bool value)
    {
        destruido = value;
    }


    public void disparar()
    {

        var municionAdelante = GameObject.Instantiate(municionEnemy, containerMunicionAdelante.transform.position, containerMunicionAdelante.transform.rotation);
        var municionizq = GameObject.Instantiate(municionEnemy, containerMunicionIzq.transform.position, containerMunicionIzq.transform.rotation);
        var municionDer = GameObject.Instantiate(municionEnemy, containerMunicionDer.transform.position, containerMunicionDer.transform.rotation);

        municionAdelante.GetComponent<Rigidbody>().velocity = rigidBody.velocity;
        municionizq.GetComponent<Rigidbody>().velocity = rigidBody.velocity;
        municionDer.GetComponent<Rigidbody>().velocity = rigidBody.velocity;

        municionAdelante.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaMunicion, ForceMode.Impulse);
        municionAdelante.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (fuerzaMunicion / 5), ForceMode.Impulse);

        municionizq.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaMunicion, ForceMode.Impulse);
        municionizq.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (fuerzaMunicion / 5), ForceMode.Impulse);

        municionDer.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaMunicion, ForceMode.Impulse);
        municionDer.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (fuerzaMunicion / 5), ForceMode.Impulse);
            
    }

    public void setPlayer(Player player)
    {
        this.player = player;
    }
}
