using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresHelper : MonoBehaviour
{
    public string SceneMenu;

    public Text txt_primerLugarPuntaje;
    public Text txt_primerLugarNombre;

    public Text txt_segundoLugarPuntaje;
    public Text txt_segundoLugarNombre;

    public Text txt_tercerLugarPuntaje;
    public Text txt_tercerLugarNombre;

    public Text txt_cuartoLugarPuntaje;
    public Text txt_cuartoLugarNombre;

    public Text txt_quintoLugarPuntaje;
    public Text txt_quintoLugarNombre;

    void Start()
    {
        txt_primerLugarNombre.text = PlayerPrefs.GetString("Pos1Nombre", "Vacío").ToUpper();
        txt_primerLugarPuntaje.text = PlayerPrefs.GetInt("Pos1", 0).ToString();

        txt_segundoLugarNombre.text = PlayerPrefs.GetString("Pos2Nombre", "Vacío").ToUpper();
        txt_segundoLugarPuntaje.text = PlayerPrefs.GetInt("Pos2", 0).ToString();

        txt_tercerLugarNombre.text = PlayerPrefs.GetString("Pos3Nombre", "Vacío").ToUpper();
        txt_tercerLugarPuntaje.text = PlayerPrefs.GetInt("Pos3", 0).ToString();

        txt_cuartoLugarNombre.text = PlayerPrefs.GetString("Pos4Nombre", "Vacío").ToUpper();
        txt_cuartoLugarPuntaje.text = PlayerPrefs.GetInt("Pos4", 0).ToString();

        txt_quintoLugarNombre.text = PlayerPrefs.GetString("Pos5Nombre", "Vacío").ToUpper();
        txt_quintoLugarPuntaje.text = PlayerPrefs.GetInt("Pos5", 0).ToString();
    }

    public void ShowMenu()
    {
        try
        {
            GameManager.instancia.cambiarEscena(SceneMenu);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }
}
