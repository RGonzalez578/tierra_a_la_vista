using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int puntajeJugador;

    //Singelton
    private static GameManager _instancia;
    public static GameManager instancia
    {
        get
        {
            return _instancia;
        }
    }
    private void Awake()
    {
        if (_instancia == null)
        {
            _instancia = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void setPuntajeJugador(int puntaje)
    {
        puntajeJugador = puntaje;
    }

    public int getPuntajeJugador()
    {
        return puntajeJugador;
    }
}
