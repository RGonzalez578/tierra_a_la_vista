using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int puntajeJugador;

    public int[] puntajes = new int[5];
    public string[] puntajesNombres = new string[5];

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

    public bool guardarPuntaje(int posicion, int valor)
    {
        try
        {
            PlayerPrefs.SetInt("Pos" + posicion.ToString(), valor);
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public int obtenerPuntajeGuardado(int posicion)
    {
        return PlayerPrefs.GetInt("Pos" + posicion.ToString(), 0);
    }

    public string obtenerNombreGuardado(int posicion)
    {
        return PlayerPrefs.GetString("Pos" + posicion.ToString() + "Nombre", "Vacío");
    }

    public void guardarDatos(int[] puntajes, string[] puntajesNombres)
    {
        for (int i = 0; i < puntajes.Length; i++)
        {
            PlayerPrefs.SetInt("Pos" + i, puntajes[i]);
        }

        for (int i = 0; i < puntajesNombres.Length; i++)
        {
            PlayerPrefs.SetString("Pos" + i + "Nombre", puntajesNombres[i]);
        }
    }

    public int[] recuperarDatosPuntajes()
    {
        for (int i = 0; i < puntajes.Length; i++)
        {
            puntajes[i] = PlayerPrefs.GetInt("Pos" + i, 0);
        }
        return puntajes;
    }

    public string[] recuperarDatosPuntajesNombres()
    {
        for (int i = 0; i < puntajesNombres.Length; i++)
        {
            puntajesNombres[i] = PlayerPrefs.GetString("Pos" + i + "Nombre", "Vacío");
        }
        return puntajesNombres;
    }
}
