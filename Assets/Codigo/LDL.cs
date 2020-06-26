using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDL {

    static public Nodo primero { get; set; }
    static public Nodo ultimo { get; set; }

    static public bool finDeRecorrido(Nodo x)
    {
        return (x.LigaConsecutiva == null);
    }
}
