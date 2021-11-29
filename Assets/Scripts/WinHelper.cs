using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinHelper : MonoBehaviour
{

    public Text txt_puntaje;

    public Text txt_primerLugarPuntaje;
    public Text txt_primerLugarNombre;

    public Text txt_segundoLugarPuntaje;
    public Text txt_segundoLugarNombre;

    public Text txt_tercerLugarPuntaje;
    public Text txt_tercerLugarNombre;

    public InputField nombreJugador;

    public int[] puntajes;
    public string[] puntajesNombres;

    private int pivote;
    private int temp;
    private string pivoteNombre;
    private string tempNombre;


    // Start is called before the first frame update
    void Start()
    {
        txt_puntaje.text = GameManager.instancia.getPuntajeJugador().ToString();

        txt_primerLugarNombre.text = PlayerPrefs.GetString("Pos1Nombre", "Vacío").ToUpper();
        txt_primerLugarPuntaje.text = PlayerPrefs.GetInt("Pos1", 0).ToString();

        txt_segundoLugarNombre.text = PlayerPrefs.GetString("Pos2Nombre", "Vacío").ToUpper();
        txt_segundoLugarPuntaje.text = PlayerPrefs.GetInt("Pos2", 0).ToString();

        txt_tercerLugarNombre.text = PlayerPrefs.GetString("Pos3Nombre", "Vacío").ToUpper();
        txt_tercerLugarPuntaje.text = PlayerPrefs.GetInt("Pos3", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickGuardarDatos()
    {
        pivoteNombre = nombreJugador.text;

        if (string.IsNullOrEmpty(pivoteNombre))
        {
            pivoteNombre = "Anónimo";
        }


        puntajes = new int[5];
        puntajesNombres = new string[5];

        puntajes = GameManager.instancia.recuperarDatosPuntajes();
        puntajesNombres = GameManager.instancia.recuperarDatosPuntajesNombres();

        pivote = GameManager.instancia.getPuntajeJugador();

        if (pivote > puntajes[0])
        {
            temp = puntajes[1];
            tempNombre = puntajesNombres[1];

            puntajes[1] = puntajes[0];
            puntajesNombres[1] = puntajesNombres[0];

            puntajes[0] = pivote;
            puntajesNombres[0] = pivoteNombre;

            pivote = temp;
            pivoteNombre = tempNombre;
        }

        if (pivote > puntajes[1])
        {
            temp = puntajes[2];
            tempNombre = puntajesNombres[2];

            puntajes[2] = puntajes[1];
            puntajesNombres[2] = puntajesNombres[1];

            puntajes[1] = pivote;
            puntajesNombres[1] = pivoteNombre;

            pivote = temp;
            pivoteNombre = tempNombre;
        }

        if (pivote > puntajes[2])
        {
            temp = puntajes[3];
            tempNombre = puntajesNombres[3];

            puntajes[3] = puntajes[2];
            puntajesNombres[3] = puntajesNombres[2];

            puntajes[2] = pivote;
            puntajesNombres[2] = pivoteNombre;

            pivote = temp;
            pivoteNombre = tempNombre;
        }

        if (pivote > puntajes[3])
        {
            temp = puntajes[4];
            tempNombre = puntajesNombres[4];

            puntajes[4] = puntajes[3];
            puntajesNombres[4] = puntajesNombres[3];

            puntajes[3] = pivote;
            puntajesNombres[3] = pivoteNombre;

            pivote = temp;
            pivoteNombre = tempNombre;
        }

        if (pivote > puntajes[4])
        {
            puntajes[4] = pivote;
            puntajesNombres[4] = pivoteNombre;
        }

        GameManager.instancia.guardarDatos(puntajes, puntajesNombres);

        GameManager.instancia.cambiarEscena("Menu");
    }
}
