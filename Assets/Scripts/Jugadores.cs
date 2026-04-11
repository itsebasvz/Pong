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
        if (Input.GetKey(teclaArriba) && Pelota.numToques<=20){ //establecemos de una vez la velocidad maxima para que no sea injugable
            rb2d.MovePosition(rb2d.position + (Vector2.up * Time.deltaTime * Juego.velJugador) + new Vector2(0,(float)Pelota.numToques/100.0f)); //vamos aumentando de manera gradual la velocidad sumamos hacia arriba por lo tanto suma en y
        }

        if(Input.GetKey(teclaAbajo) && Pelota.numToques<=20){
            rb2d.MovePosition(rb2d.position + (Vector2.down * Time.deltaTime * Juego.velJugador) - new Vector2(0,(float)Pelota.numToques/100.0f)); //restamos hacia abajo por lo tanto resta en y
        }
    }
}
