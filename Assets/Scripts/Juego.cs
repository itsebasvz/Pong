using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip sndSilbato, sndGameOver;
    public Text txtGameOver;

    private GameObject txtMarcador;
    private GameObject pelota;

    public static float velBola = 5.0f, velJugador = 8.0f;
    private int signoX, signoY, velocidad = 4; //Direccion en las que se mueve en horiz o vert


    void Start()
    {
        txtGameOver.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("pelota");
        txtMarcador = GameObject.Find("txtMarcador");
        txtMarcador.GetComponent<Text>().text = "0 - 0";

        //Movimeiento de la pelota
        if (Random.Range(0, 1) > 0.5f)
        {
            signoX = 1;
        }
        else
        {
            signoX = -1;
        }
        StartCoroutine(ArbitroPitaInicio());
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
        }
        if (Pelota.golesJugadorDer == 2 || Pelota.golesJugadorIzq == 2) //terminamos el juego si llegamos al limite de goles permitido
        {
            if (Input.anyKey)
            {
                Pelota.golesJugadorDer = 0;
                Pelota.golesJugadorIzq = 0;
                SceneManager.LoadScene("Configuracion");
            }
        }
    }

    public void EscribeMarcador()
    {
        txtMarcador.GetComponent<Text>().text = Pelota.golesJugadorIzq.ToString() + " - " + Pelota.golesJugadorDer.ToString();
        if (Pelota.golesJugadorDer == 2 || Pelota.golesJugadorIzq == 2) //terminamos el juego si llegamos al limite de goles permitido
        {
            txtGameOver.gameObject.SetActive(true);
            audio.clip = sndGameOver;
            audio.Play();
        }
        else //si se anoto un gol
        {
            StartCoroutine(ArbitroPitaInicio());
        }
    }

    //Co - rutina
    IEnumerator ArbitroPitaInicio()
    {
        yield return new WaitForSeconds(1.0f);
        LanzaPelota();
    }

    public void LanzaPelota()
    {
        audio.clip = sndSilbato;
        audio.Play();  //Ejecuta el sonido de silbato
        pelota.transform.position = gameObject.transform.position = new Vector3(0, 0, 0); //Reseteo de la pelota, posicion.
        signoY = Random.Range(0, 1) > 0.5f ? 1 : -1;
        pelota.GetComponent<Rigidbody2D>().velocity = new Vector2(signoX * velocidad, signoY * velocidad);
    }

}