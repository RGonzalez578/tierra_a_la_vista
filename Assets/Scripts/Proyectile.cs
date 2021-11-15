using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    private float transformX;
    private float transformY;
    private float transformZ;

    public int oroEliminado = 1;
    public GameObject oro;
    public Gold gold;

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
            player.restarOro(oroEliminado);

            var container = player.transform.GetChild(23);

            //Debug.Log(""+ container.transform.position.x + "---" + container.transform.position.z);

            transformX = container.transform.position.x;
            transformY = 10;
            transformZ = container.transform.position.z;

            GameObject.Instantiate(oro);

            var prefabOro = oro.GetComponent<Gold>();
            prefabOro.posicionar(transformX, transformY, transformZ);
            //Debug.Log("" + prefabOro.transform.position.x + "---" + prefabOro.transform.position.z);
        }
    }
}