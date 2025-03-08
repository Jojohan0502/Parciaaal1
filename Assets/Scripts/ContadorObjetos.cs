using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContadorObjetos : MonoBehaviour
{
    public static int monedas = 0;
    public static int barrasChocolate = 0;

    public Text textoMonedas;
    public Text textoBarras;

    void Start()
    {
        ActualizarUI();
    }

    public void RecogerMoneda()
    {
        monedas++;
        PlayerPrefs.SetInt("Monedas", monedas);
        ActualizarUI();
    }

    public void RecogerBarra()
    {
        barrasChocolate++;
        PlayerPrefs.SetInt("BarrasChocolate", barrasChocolate);
        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoMonedas.text = "Monedas: " + monedas;
        textoBarras.text = "Barras: " + barrasChocolate;
    }
}
