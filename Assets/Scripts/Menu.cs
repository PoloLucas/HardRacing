using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
        Debug.Log("Con este Boton comienza el Juego");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Con este Boton se cierra el Juego");
    }

}
