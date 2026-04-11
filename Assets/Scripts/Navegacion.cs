using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour {
    void Update() {
        if (Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("Configuracion");
        }
    }

    public void InicioAConfiguracion()
    {
        SceneManager.LoadScene("Configuracion");
    }
    public void ConfiguracionAInicio()
    {
        SceneManager.LoadScene("Inicio");
    }

}