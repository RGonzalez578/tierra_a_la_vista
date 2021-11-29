using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilePlayer : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Floater>().setDestruido(true);
            other.gameObject.GetComponent<Enemy>().setDestruido(true);
            Debug.Log("Destruido");
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(other.gameObject, 3);
            player.sumarEnemigosEliminados();
        }
    }
}
