using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int oroRecuperado = 1;

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

            if (player.getOro() < 1000)
            {
                player.sumarOro(oroRecuperado);
            }

            Destroy(this.gameObject);
        }
    }

    public void posicionar(float X, float Y, float Z)
    {
        transform.position = new Vector3(X, Y, Z);
    }
}
