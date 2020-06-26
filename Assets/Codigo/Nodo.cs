using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo
{
    public object Indicador { get; set; }
    public Nodo LigaIndicadora { get; set; }
    public Nodo LigaConsecutiva { get; set; }
    public GameObject casilla;

    public Nodo(object indicador, Nodo ligaIndicadora, Nodo ligaConsecutiva, GameObject casilla)
    {
        this.Indicador = indicador;
        this.LigaIndicadora = ligaIndicadora;
        this.LigaConsecutiva = ligaConsecutiva;
        this.casilla = casilla;
    }


}