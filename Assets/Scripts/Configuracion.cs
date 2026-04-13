using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuracion : MonoBehaviour
{
    // Estos son los INDICADORES (las líneas o subrayados)
    public GameObject subrayadoCPU, subrayado2J;
    public GameObject subrayadoIzq, subrayadoDer;

    public static int tipoJuego = 1;
    public static int ladoJugador = 1;

    void Awake()
    {
        // Estado inicial: CPU y Lado Izquierdo seleccionados
        ActualizarVisualizacionModo();
        ActualizarVisualizacionLado();
    }

    void Update()
    {
        // Selección de modo
        if (Input.GetKeyDown(KeyCode.Alpha1)) { Op1Seleccion(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { Op2Seleccion(); }

        // Selección de lado (BLOQUEADO: SOLO FUNCIONA SI TIPO JUEGO ES 1)
        if (tipoJuego == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)) { Op3Seleccion(); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { Op4Seleccion(); }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }

    // Funciones de selección para Botones o Teclado
    public void Op1Seleccion()
    {
        tipoJuego = 1;
        ActualizarVisualizacionModo();
        ActualizarVisualizacionLado(); // Refrescamos para prender el lado
    }

    public void Op2Seleccion()
    {
        tipoJuego = 2;
        ActualizarVisualizacionModo();
        ActualizarVisualizacionLado(); // Refrescamos para apagar el lado
    }

    public void Op3Seleccion()
    {
        // Doble candado de seguridad por si usas el mouse y haces clic en el botón
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

    void ActualizarVisualizacionModo()
    {
        if (subrayadoCPU != null) subrayadoCPU.SetActive(tipoJuego == 1);
        if (subrayado2J != null) subrayado2J.SetActive(tipoJuego == 2);
    }

    void ActualizarVisualizacionLado()
    {
        // Evaluamos si mostrar los indicadores dependiendo del modo de juego
        if (tipoJuego == 1)
        {
            // Muestra el subrayado correspondiente a la elección
            if (subrayadoIzq != null) subrayadoIzq.SetActive(ladoJugador == 1);
            if (subrayadoDer != null) subrayadoDer.SetActive(ladoJugador == 2);
        }
        else if (tipoJuego == 2)
        {
            // Apaga ambos subrayados si estamos jugando contra otra persona
            if (subrayadoIzq != null) subrayadoIzq.SetActive(false);
            if (subrayadoDer != null) subrayadoDer.SetActive(false);
        }
    }

    public void ConfiguracionAMain() { SceneManager.LoadScene("Main"); }
}