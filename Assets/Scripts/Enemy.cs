using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 anguloRotacion;

    public float velocidad = 1.5f;
    public Vector3 playerPosition;
    public Vector3 enemyPosition;
    public Player player;

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        playerPosition = player.transform.position;
        enemyPosition = transform.position;

        float x = playerPosition.x;
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


        rigidBody.AddRelativeForce(Vector3.forward * -1 * (velocidad / 2));

    }
}
