using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour
{
    public string SceneGame;
    public string SceneScores;
    public string SceneInstructions;
    public string SceneCredits;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void StartGame()
    {
        try
        {
            GameManager.instancia.cambiarEscena(SceneGame);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvid? poner el GameManager en la escena" + ex);
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
            Debug.Log("Se te olvid? poner el GameManager en la escena" + ex);
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
            Debug.Log("Se te olvid? poner el GameManager en la escena" + ex);
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
            Debug.Log("Se te olvid? poner el GameManager en la escena" + ex);
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
            Debug.Log("Se te olvid? poner el GameManager en la escena" + ex);
        }
    }

}
