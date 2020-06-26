using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour {

    // La representacion del nodo sera:  INDICADOR - LIGA INDICADORA - LIGA CONSECUTIVA

    private object indicador; 
    private Casilla ligaIndicadora, ligaConsecutiva;
    private GameObject bloque;


    public Casilla(Casilla ligaConsecutiva, GameObject bloque)
    {
        indicador = null;
        ligaIndicadora = null;
        this.ligaConsecutiva = ligaConsecutiva;
        this.bloque = bloque;
    }


    public Casilla()      // CONSTRUCTOR
    {
        indicador = 0;
        ligaConsecutiva = null;
    }


    public void setIndicador(object x)
    {
        indicador = x;
    }

    public object getIndicador()
    {
        return indicador;
    }


    public void setLigaIndicadora(Casilla d)
    {
        ligaIndicadora = d;
    }

    public Casilla getLigaIndicadora()
    {
        return ligaIndicadora;
    }
    

    public void SetLigaConsecutiva(Casilla x)
    {
        ligaConsecutiva = x;
    }

    public Casilla getLigaConsecutiva()
    {
        return ligaConsecutiva;
    }

    public void setBloque(GameObject b)
    {
        bloque = b;
    }

    public GameObject getBloque()
    {
        return bloque;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
