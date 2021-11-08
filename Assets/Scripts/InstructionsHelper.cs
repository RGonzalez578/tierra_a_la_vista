using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsHelper : MonoBehaviour
{
    public string SceneMenu;

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
