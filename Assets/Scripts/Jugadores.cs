using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour
{
    public KeyCode teclaArriba, teclaAbajo;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verificamos si esta paleta específica debe ser controlada por el teclado
        bool soyJugadorIzq = (gameObject.name == "jugadorIzq" && Configuracion.ladoJugador == 1);
        bool soyJugadorDer = (gameObject.name == "jugadorDer" && Configuracion.ladoJugador == 2);
        bool esDosJugadores = (Configuracion.tipoJuego == 2);

        // Solo permitimos el movimiento si es la paleta elegida o si es modo 2 jugadores
        if (soyJugadorIzq || soyJugadorDer || esDosJugadores)
        {
            if (Input.GetKey(teclaArriba) && Pelota.numToques <= 20)
            {
                rb2d.MovePosition(rb2d.position + (Vector2.up * Time.deltaTime * Juego.velJugador) + new Vector2(0, (float)Pelota.numToques / 100.0f));
            }

            if (Input.GetKey(teclaAbajo) && Pelota.numToques <= 20)
            {
                rb2d.MovePosition(rb2d.position + (Vector2.down * Time.deltaTime * Juego.velJugador) - new Vector2(0, (float)Pelota.numToques / 100.0f));
            }
        }
    }
}