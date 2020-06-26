using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad;
    public bool puedeMover { get; set; }
    public int posicion { get; set; }
    public Nodo inicio { get; set; }
    public Nodo actual { get; set; }
    public Nodo destino { get; set; }


    // Use this for initialization
    void Awake()
    {
        puedeMover = false;
    }

    private void Update()
    {
        if (puedeMover)
        {
            MoverFicha();
        }
    }

    private void Start()
    {
        inicio = LDL.primero;
        actual = inicio;
    }

    public void MoverFicha()
    {
        if (transform.position != destino.casilla.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            destino.casilla.transform.position,
            velocidad * Time.deltaTime);
        }
        else if (posicion < Jugabilidad.diceSideThrown)
        {
            actual = destino;
            destino = destino.LigaConsecutiva;
            posicion++;
        }
        else
        {
            actual = destino;
            if (actual.Indicador != null && (int)actual.Indicador == 0)
            {
                destino = actual.LigaIndicadora;
            }
            else if (actual.Indicador != null && (int)actual.Indicador == 1)
            {
                destino = actual.LigaIndicadora;
            }
            else
            {
                puedeMover = false;
                
            }

        }
        if(!puedeMover) ComprobarMaquina();
        Rotar(destino);

        if (actual == LDL.ultimo)
        {
            Jugabilidad.GameOver();
        }
    }

    public void ComprobarMaquina()
    {
        Dado dado = GameObject.FindGameObjectWithTag("Dado").GetComponent<Dado>();
        if (Jugabilidad.vsMachine && dado.whosTurn == -1) dado.Clicked();
    }

    public void Rotar(Nodo destino)
    {
        if (transform.position.z < destino.casilla.transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (transform.position.x > destino.casilla.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (transform.position.x < destino.casilla.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
