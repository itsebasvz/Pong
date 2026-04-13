using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionDificultad : MonoBehaviour
{
    // Arrastra aquí tus objetos de texto que tienen los guiones "-------"
    public GameObject subFacil, subNormal, subDificil, subImposible;

    public static int nivelDificultad = 2; // Por defecto Normal

    void Awake()
    {
        // Al entrar a la escena, mostramos cuál está seleccionado por defecto
        ActualizarVisualizacion();
    }

    void Update()
    {
        // Selección con teclado
        if (Input.GetKeyDown(KeyCode.Alpha1)) { OpFacil(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { OpNormal(); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { OpDificil(); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { OpImposible(); }

        // Iniciar el juego
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }

        // Regresar a configuración
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Configuracion");
        }
    }

    // Funciones para botones y teclado
    public void OpFacil() { nivelDificultad = 1; ActualizarVisualizacion(); }
    public void OpNormal() { nivelDificultad = 2; ActualizarVisualizacion(); }
    public void OpDificil() { nivelDificultad = 3; ActualizarVisualizacion(); }
    public void OpImposible() { nivelDificultad = 4; ActualizarVisualizacion(); }

    void ActualizarVisualizacion()
    {
        // Solo prendemos/apagamos los subrayados, los textos principales se quedan siempre activos en Unity
        if (subFacil != null) subFacil.SetActive(nivelDificultad == 1);
        if (subNormal != null) subNormal.SetActive(nivelDificultad == 2);
        if (subDificil != null) subDificil.SetActive(nivelDificultad == 3);
        if (subImposible != null) subImposible.SetActive(nivelDificultad == 4);
    }
}