using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuracion : MonoBehaviour
{
    public Text op1, op2;
    public static int tipoJuego = 1; //1 - VS la CPU, 2 vs otra persona

    void Awake()
    {
        tipoJuego = 1;
        op1.gameObject.SetActive(true);
        op2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            BorraSubrayado();
            op1.gameObject.SetActive(true);
            tipoJuego = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            BorraSubrayado();
            op2.gameObject.SetActive(true);
            tipoJuego = 2;
        }
        if (Input.GetKey(KeyCode.Space)) //Barra espaciadora a Main
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void BorraSubrayado()
    {
        op1.gameObject.SetActive(false);
        op2.gameObject.SetActive(false);
    }

    public void Op1Seleccion() //Botón Op1
    {
        BorraSubrayado();
        op1.gameObject.SetActive(true);
        tipoJuego = 1;
    }

    public void Op2Seleccion() //Botón Op2
    {
        BorraSubrayado();
        op2.gameObject.SetActive(true);
        tipoJuego = 2;
    }

    public void ConfiguracionAMain()
    {
        SceneManager.LoadScene("Main");
    }
}