using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuracion : MonoBehaviour
{
    [Header("Indicadores Visuales (Rayitas o Textos)")]
    public GameObject subrayadoCPU;
    public GameObject subrayado2J;
    public GameObject subrayadoIzq;
    public GameObject subrayadoDer;

    // Variables globales que leerán los otros scripts
    public static int tipoJuego = 1;
    public static int ladoJugador = 1;

    void Awake()
    {
        // Estado inicial por defecto: CPU y Lado Izquierdo
        tipoJuego = 1;
        ladoJugador = 1;

        ActualizarVisualizacionModo();
        ActualizarVisualizacionLado();
    }

    void Update()
    {
        // --- SELECCIÓN DE MODO DE JUEGO ---
        if (Input.GetKeyDown(KeyCode.Alpha1)) { Op1Seleccion(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { Op2Seleccion(); }

        // --- SELECCIÓN DE LADO (Solo si es contra la CPU) ---
        if (tipoJuego == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)) { Op3Seleccion(); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { Op4Seleccion(); }
        }

        // --- INICIAR JUEGO CON TECLADO ---
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConfiguracionAMain();
        }
        // --- REGRESAR AL INICIO ---
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
        }
    }

    // --- FUNCIONES PARA LOS BOTONES DE LA INTERFAZ ---

    public void Op1Seleccion()
    {
        tipoJuego = 1;
        ActualizarVisualizacionModo();
        ActualizarVisualizacionLado(); // Refrescamos para que reaparezcan los lados
    }

    public void Op2Seleccion()
    {
        tipoJuego = 2;
        ActualizarVisualizacionModo();
        ActualizarVisualizacionLado(); // Refrescamos para apagar los lados
    }

    public void Op3Seleccion()
    {
        if (tipoJuego == 1)
        {
            ladoJugador = 1;
            ActualizarVisualizacionLado();
        }
    }

    public void Op4Seleccion()
    {
        if (tipoJuego == 1)
        {
            ladoJugador = 2;
            ActualizarVisualizacionLado();
        }
    }

    // --- FUNCIONES VISUALES (Prender y apagar las rayitas) ---

    void ActualizarVisualizacionModo()
    {
        if (subrayadoCPU != null) subrayadoCPU.SetActive(tipoJuego == 1);
        if (subrayado2J != null) subrayado2J.SetActive(tipoJuego == 2);
    }

    void ActualizarVisualizacionLado()
    {
        // Si jugamos contra la CPU, mostramos qué lado elegimos
        if (tipoJuego == 1)
        {
            if (subrayadoIzq != null) subrayadoIzq.SetActive(ladoJugador == 1);
            if (subrayadoDer != null) subrayadoDer.SetActive(ladoJugador == 2);
        }
        // Si jugamos contra otra persona, apagamos ambas opciones de lado
        else if (tipoJuego == 2)
        {
            if (subrayadoIzq != null) subrayadoIzq.SetActive(false);
            if (subrayadoDer != null) subrayadoDer.SetActive(false);
        }
    }

    // --- EL PUENTE HACIA LAS OTRAS ESCENAS ---

    public void ConfiguracionAMain()
    {
        Debug.Log("Iniciando. Modo seleccionado: " + tipoJuego);

        if (tipoJuego == 1)
        {
            // Si es contra la IA, pasamos a elegir qué tan difícil será
            Debug.Log("Cargando escena: Dificultad");
            SceneManager.LoadScene("Dificultad");
        }
        else
        {
            // Si es 2 Jugadores, vamos directo a la cancha
            Debug.Log("Cargando escena: Main");
            SceneManager.LoadScene("Main");
        }
    }
}