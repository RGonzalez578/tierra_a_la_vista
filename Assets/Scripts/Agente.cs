using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public int distancia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, target.position) < distancia)
        {
            
            agent.SetDestination(target.position);
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
