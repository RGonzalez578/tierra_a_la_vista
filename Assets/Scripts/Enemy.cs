using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 anguloRotacion;
    private bool destruido;

    public float velocidad = 1.5f;
    public Vector3 playerPosition;
    public Vector3 enemyPosition;
    public Player player;

    
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
                transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, velocidad * Time.deltaTime);
                transform.forward = playerPosition - transform.position;
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
            anguloRotacion = (new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1))) * velocidad;
            Quaternion deltaRotation = Quaternion.Euler(anguloRotacion * Time.fixedDeltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }

    }

    public void setDestruido(bool value)
    {
        destruido = value;
    }
}
