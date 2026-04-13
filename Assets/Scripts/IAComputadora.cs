using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAComputadora : MonoBehaviour
{
    public GameObject MiPelota;
    Vector3 posicionPelota;

    private GameObject jugador1, jugador2;

    void Start()
    {
        jugador1 = GameObject.Find("jugadorIzq").gameObject;
        jugador2 = GameObject.Find("jugadorDer").gameObject;

        if (MiPelota == null)
        {
            MiPelota = GameObject.Find("pelota");
        }
    }

    void Update()
    {
        if (Configuracion.tipoJuego == 1)
        {
            bool soyIADerecha = (gameObject.name == "jugadorDer" && Configuracion.ladoJugador == 1);
            bool soyIAIzquierda = (gameObject.name == "jugadorIzq" && Configuracion.ladoJugador == 2);

            if (soyIADerecha || soyIAIzquierda)
            {
                // Variables para configurar el comportamiento en este frame
                float velocidadBase = 0f;
                float divisorAceleracion = 1000f; // Entre más alto, menos acelera

                // Control manual y exacto por nivel
                switch (SeleccionDificultad.nivelDificultad)
                {
                    case 1: // FÁCIL: Súper lenta, apenas acelera.
                        velocidadBase = 1.5f;
                        divisorAceleracion = 3000f;
                        break;
                    case 2: // NORMAL: Un reto decente.
                        velocidadBase = 3.5f;
                        divisorAceleracion = 1000f;
                        break;
                    case 3: // DIFÍCIL: Muy ágil.
                        velocidadBase = 6.0f;
                        divisorAceleracion = 500f;
                        break;
                    case 4: // IMPOSIBLE: Rápida desde el inicio, acelera de locos.
                        velocidadBase = 8.5f;
                        divisorAceleracion = 200f;
                        break;
                }

                // Ahora sí, toda la suma matemática está protegida por Time.deltaTime
                float velocidadCalculada = velocidadBase + ((float)Pelota.numToques / divisorAceleracion);
                float pasoMovimiento = velocidadCalculada * Time.deltaTime;

                posicionPelota = MiPelota.gameObject.transform.position;

                if (posicionPelota.x >= -9 && posicionPelota.x <= 9)
                {
                    transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, posicionPelota.y, 0), pasoMovimiento);
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