using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jugadores : MonoBehaviour
{
    public KeyCode teclaArriba, teclaAbajo;
    private Rigidbody2D rb2d;
    

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();    //Espera elemento que tenga la clase para que tenga rigidbody2d dewntro de la clase jugadres
    }

    // Movimiento, desplazamiento de arriba hacia abajo, x, y

    void Update() {
        if (Input.GetKey(teclaArriba)){
            rb2d.MovePosition(rb2d.position + (Vector2.up * Time.deltaTime * Juego.velJugador) );
        }

        if(Input.GetKey(teclaAbajo)){
            rb2d.MovePosition(rb2d.position + (Vector2.down * Time.deltaTime * Juego.velJugador) );
        }
    }
}
