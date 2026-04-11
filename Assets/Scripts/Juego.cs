using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Juego : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip sndSilbato, sndGameOver;
    public Text txtGameOver;

    private GameObject txtMarcador;
    private GameObject pelota;

    public static float velBola = 5.0f, velJugador = 4.5f;
    public int signoX, signoY, velocidad = 1; //Direccion en las que se mueve en horiz o vert
    
    
    void Start() {
        txtGameOver.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("pelota");
        txtMarcador = GameObject.Find("txtMarcador");
        txtMarcador.GetComponent<Text>().text = "0 - 0";

//Movimeiento de la pelota
        if(Random.Range(0,1) > 0.5f) {
            signoX = 1;
        } else {
            signoX = -1;
        }
        StartCoroutine(ArbitroPitaInicio());
    }


    void Update()
    {
        
    }

//Co - rutina
    IEnumerator ArbitroPitaInicio() {
        yield return new WaitForSeconds(3.0f);
        LanzaPelota();
    }

    public void LanzaPelota() {
        audio.clip = sndSilbato;
        audio.Play();  //Ejecuta el sonido de silbato
        pelota.transform.position = gameObject.transform.position = new Vector3(0, 0, 0); //Reseteo de la pelota, posicion.
        signoY = Random.Range(0, 1) > 0.5f ? 1 : -1;
        pelota.GetComponent<Rigidbody2D>().velocity = new Vector2(signoX * velocidad, signoY * velocidad);
    }

}
