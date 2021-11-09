using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour
{
    public string SceneGame;
    public string SceneScores;
    public string SceneInstructions;
    public string SceneCredits;

    public void StartGame()
    {
        try
        {
            GameManager.instancia.cambiarEscena(SceneGame);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }

    public void ShowScores()
    {
        try
        {
            GameManager.instancia.cambiarEscena(SceneScores);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }

    public void ShowInstructions()
    {
        try
        {
            GameManager.instancia.cambiarEscena(SceneInstructions);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }

    public void ShowCredits()
    {
        try
        {
            GameManager.instancia.cambiarEscena(SceneCredits);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }

    public void Exit()
    {
        try
        {
            GameManager.instancia.Salir();
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }

}
