using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    private float transformX;
    private float transformY;
    private float transformZ;
    private Rigidbody rigidbody;

    public int oroEliminado = 1;
    public GameObject oro;
    public float fuerza = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            var player = other.GetComponent<Player>();

            if (!player.getProtegido())
            {
                player.restarOro(oroEliminado);

                // Se obtiene la posici?n del spawn point
                var container = player.transform.GetChild(24);

                //Debug.Log(""+ container.transform.position.x + "---" + container.transform.position.z);

                transformX = container.transform.position.x;
                transformY = 11;
                transformZ = container.transform.position.z;

                int randomX = Random.Range(-1, 1);
                int randomY = Random.Range(-1, 1);

                var prefabOro = GameObject.Instantiate(oro, new Vector3(transformX, transformY, transformZ), Quaternion.Euler(0, 0, 0));
                rigidbody = prefabOro.GetComponent<Rigidbody>();
                rigidbody.AddRelativeForce(new Vector3(randomX, transformY, randomY) * fuerza, ForceMode.Impulse);
                rigidbody.AddRelativeForce(Vector3.up * fuerza, ForceMode.Impulse);
                //prefabOro.posicionar(transformX, transformY, transformZ);
                //Debug.Log("" + prefabOro.transform.position.x + "---" + prefabOro.transform.position.z);
            }
        }
    }
}
