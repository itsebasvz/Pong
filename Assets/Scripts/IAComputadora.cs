using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAComputadora : MonoBehaviour
{
    public GameObject MiPelota;
    Vector3 posicionPelota;
    float velocidad = 1.0f;
    private GameObject jugador1, jugador2;

    void Start()
    {
        jugador1 = GameObject.Find("jugadorIzq").gameObject;
        jugador2 = GameObject.Find("jugadorDer").gameObject;

        // Auto-asignar la pelota si no se asignó en el inspector
        if (MiPelota == null)
        {
            MiPelota = GameObject.Find("pelota");
        }
    }

    void Update()
    {
        if (Configuracion.tipoJuego == 1)
        {
            // Si tú elegiste izquierda (1), la IA debe mover la derecha. Si tú elegiste derecha (2), la IA mueve la izquierda.
            bool soyIADerecha = (gameObject.name == "jugadorDer" && Configuracion.ladoJugador == 1);
            bool soyIAIzquierda = (gameObject.name == "jugadorIzq" && Configuracion.ladoJugador == 2);

            if (soyIADerecha || soyIAIzquierda)
            {
                float deltaY = velocidad * Time.deltaTime + (float)Pelota.numToques / 600.0f;
                posicionPelota = MiPelota.gameObject.transform.position;

                if (posicionPelota.x >= -9 && posicionPelota.x <= 9)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, posicionPelota.y, 0), deltaY);
                }
                else
                {
                    jugador1.transform.position = new Vector3(-8, 0, 0);
                    jugador2.transform.position = new Vector3(8, 0, 0);
                }
            }
        }
    }
}