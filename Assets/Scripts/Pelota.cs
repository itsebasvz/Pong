using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Juego miJuego;
    private AudioSource audio;
    public AudioClip snd1, snd2, sndGol, sndPared;

    public static int numToques = 0, golesJugadorIzq = 0, golesJugadorDer = 0;
   
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
        miJuego = GameObject.Find("juego").gameObject.GetComponent<Juego>();
    }


    private void OnTriggerEnter2D(Collider2D colision) //funcion que detecta colisiones
    {
      float compX = 0, compY =0;  // colision de la pelota respecto al jugador

      if (colision.CompareTag("gol")) // para saber con que porteria pega
        {
            audio.clip = sndGol;
            audio.Play();
            numToques = 0;

            GameObject nombrePorteria = colision.gameObject; //guardamos el nombre del objeto con el que esta colisionando
            if (nombrePorteria.name == "porteriaIzq") //incrementamos goles dependiendo de con quien colisione
            {
                golesJugadorDer++;
            } else if (nombrePorteria.name == "porteriaDer")
            {
                golesJugadorIzq++;
            }

            miJuego.EscribeMarcador();
        }

        if (colision.CompareTag("jugadorIzq")) //para saber si colisiono con el jugador izquierdo
        {
            audio.clip = snd1;
            audio.Play();
            numToques++;

            float alturaColisionIzq = GameObject.Find("jugadorIzq").gameObject.transform.position.y - transform.position.y;
            compX = Mathf.Cos(alturaColisionIzq);
            compY = Mathf.Sin(alturaColisionIzq);

            if (alturaColisionIzq >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques , compY * (Juego.velBola * -1) - (float) numToques/2);
            } else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques , compY * (Juego.velBola * -1) + (float) numToques/2);
            }
        }

        if (colision.CompareTag("jugadorDer")) //para saber si colisiono con el jugador derecho
        {
             audio.clip = snd2;
            audio.Play();
            numToques++;

            float alturaColisionDer = GameObject.Find("jugadorDer").gameObject.transform.position.y - transform.position.y;
            compX = Mathf.Cos(alturaColisionDer);
            compY = Mathf.Sin(alturaColisionDer);

            if (alturaColisionDer >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques , compY * (Juego.velBola * -1) - (float) numToques/2);
            } else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques , compY * (Juego.velBola * -1) + (float) numToques/2);
            }
        }

        if (colision.CompareTag("pared")) //para con que pared colisiono
        {
            audio.clip = sndPared;
            audio.Play();
        }
    }

}