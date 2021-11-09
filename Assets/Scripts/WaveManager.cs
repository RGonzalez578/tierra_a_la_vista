using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instancia;

    public float alturaInicial = 9f;    
    public float amplitud = 1f;
    public float largo = 2f;
    public float vel = 1f;
    public float contrapeso = 0f;
    

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Debug.Log("¡La instancia ya existe!");
            Destroy(this);
        }
    }

    private void Update()
    {
        contrapeso += Time.deltaTime * vel;
    }

    public float GetAltoOlaBarco (float _x)
    {
        float altoOla = alturaInicial + (amplitud * Mathf.Sin(_x / largo + contrapeso));
        return altoOla;
    }

    public float GetAltoOla(float _x)
    {
        return amplitud * Mathf.Sin(_x / largo + contrapeso);
    }
}
