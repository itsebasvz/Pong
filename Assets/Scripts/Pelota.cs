using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Juego miJuego;
    private AudioSource audio;
    public AudioClip snd1, snd2, sndGol, sndPared;

    public static int numToques = 0, golesJugadorIzq = 0, golesJugadorDer = 0;

    private bool golAnotado = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        miJuego = GameObject.Find("juego").gameObject.GetComponent<Juego>();
        golAnotado = false;
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
      
        // Si el candado está cerrado (ya se metió gol), la función hace "return" 
        // y se cancela inmediatamente. La pelota ignora paletas, paredes y todo lo demás.
        if (golAnotado) return;

        float compX = 0, compY = 0;

        // --- COLISIÓN CON LA ZONA DE GOL ---
        if (colision.CompareTag("gol"))
        {
            golAnotado = true; // CERRAMOS EL CANDADO

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = new Vector3(0, 0, 0);

            audio.clip = sndGol;
            audio.Play();
            numToques = 0;

            GameObject nombrePorteria = colision.gameObject;

            if (nombrePorteria.name == "porteriaIzq")
            {
                golesJugadorDer++;
            }
            else if (nombrePorteria.name == "porteriaDer")
            {
                golesJugadorIzq++;
            }

            miJuego.EscribeMarcador();

            // Programamos que el escudo se desactive en 1 segundo
            Invoke("QuitarCandadoGol", 1.0f);
        }

        // --- COLISIÓN CON EL JUGADOR IZQUIERDO ---
        if (colision.CompareTag("jugadorIzq"))
        {
            audio.clip = snd1;
            audio.Play();
            numToques++;

            float alturaColisionIzq = GameObject.Find("jugadorIzq").gameObject.transform.position.y - transform.position.y;
            compX = Mathf.Cos(alturaColisionIzq);
            compY = Mathf.Sin(alturaColisionIzq);

            if (alturaColisionIzq >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques, compY * (Juego.velBola * -1) - (float)numToques / 2);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques, compY * (Juego.velBola * -1) + (float)numToques / 2);
            }
        }

        // --- COLISIÓN CON EL JUGADOR DERECHO ---
        if (colision.CompareTag("jugadorDer"))
        {
            audio.clip = snd2;
            audio.Play();
            numToques++;

            float alturaColisionDer = GameObject.Find("jugadorDer").gameObject.transform.position.y - transform.position.y;
            compX = Mathf.Cos(alturaColisionDer);
            compY = Mathf.Sin(alturaColisionDer);

            if (alturaColisionDer >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques, compY * (Juego.velBola * -1) - (float)numToques / 2);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques, compY * (Juego.velBola * -1) + (float)numToques / 2);
            }
        }

        // --- COLISIÓN CON LA PARED ---
        if (colision.CompareTag("pared"))
        {
            audio.clip = sndPared;
            audio.Play();
        }
    }

    void QuitarCandadoGol()
    {
        golAnotado = false;
    }
}