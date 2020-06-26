using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crear_Mundo : MonoBehaviour
{
    public GameObject Prefab;
    public Color color1;
    public Color color2;
    public Color startColor;
    public Color endColor;
    public Slider filas;
    public Slider Columnas;
    public static bool enJuego = false;
    public GameObject snakePrefab;
    public GameObject ladderPrefab;
    public Slider laddersPercent;
    public Slider snakesPercent;
    public Toggle vsMachine;

    public static int numFilas;
    public static int numColumnas;
    Nodo[] nodos;


    public void OnIniciar()
    {
        numFilas = (int)filas.value;
        numColumnas = (int)filas.value;
        Crear();
        enJuego = true; 
    }




    public void Crear()
    {
        int contadorCasillas = 0;
        Nodo anterior = null;
        nodos = new Nodo[numColumnas * numFilas + 1];

        //Los siguientes dos ciclos se usan para la creación del tablero
        for (int i = 0; i < numFilas; i++)
        {
            for (int j = 0; j < numColumnas; j++)
            {
                contadorCasillas++;
                //Se usa una variable auxiliar para determinar la direccion (horizontal) de la creacion de casillas
                int auxj = (i % 2 == 0) ? j : numColumnas - j - 1;

                //Creacion de cada casilla (gameObject), asignando posicion, color y numero de casilla
                GameObject newCell = Instantiate(Prefab, new Vector3(auxj, 0, i), Quaternion.identity, transform);
                newCell.GetComponent<Renderer>().material.color = ((contadorCasillas) % 2 == 0) ? color1 : color2;
                newCell.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = contadorCasillas + "";

                //Se asigna la casilla a nuevo nodo para posteriormente guardarlo en una LDL de nodos
                LDL.ultimo = new Nodo(null, null, null, newCell);
                nodos[contadorCasillas] = LDL.ultimo;
                if (anterior == null)
                {
                    LDL.primero = LDL.ultimo;
                    anterior = LDL.ultimo;
                }
                anterior.LigaConsecutiva = LDL.ultimo;
                anterior = LDL.ultimo;
            }
        }
        if (vsMachine.isOn) Jugabilidad.vsMachine = true;

        LDL.primero.casilla.GetComponent<Renderer>().material.color = startColor;
        LDL.ultimo.casilla.GetComponent<Renderer>().material.color = endColor;
        
        CreateLadders();
        CreateSnakes();
        

        Jugabilidad.player1.GetComponent<Jugador>().inicio = LDL.primero;
        Jugabilidad.player1.GetComponent<Jugador>().actual = LDL.primero;
        Jugabilidad.player2.GetComponent<Jugador>().inicio = LDL.primero;
        Jugabilidad.player2.GetComponent<Jugador>().actual = LDL.primero;
    }

    public void CreateSnakes()
    {
        int snakesAmount = (int)(((float)(numColumnas * numFilas) / 100f) * (float)snakesPercent.value / 2);
        int half = (numColumnas * numFilas) / 2;
        Nodo start;
        Nodo end;
        GameObject newSnake;
        int inicio, fin;

        for (int i = 0; i < snakesAmount; i++)
        {
            do
            {
                inicio = Random.Range(2, nodos.Length - numColumnas);
                fin = Random.Range(inicio + numColumnas, nodos.Length - 6);
                start = nodos[fin];
                end = nodos[inicio];
            } while (start.Indicador != null && (int)start.Indicador == 0);

            start.Indicador = (object)0;
            start.LigaIndicadora = end;
            newSnake = Instantiate(snakePrefab);
            newSnake.GetComponent<LineRenderer>().SetPosition(1, new Vector3(start.casilla.transform.position.x, 0.3f, start.casilla.transform.position.z));
            newSnake.GetComponent<LineRenderer>().SetPosition(0, new Vector3(end.casilla.transform.position.x, 0.3f, end.casilla.transform.position.z));
        }
    }

    public void CreateLadders()
    {
        int laddersAmount = (int)(((float)(numColumnas * numFilas) / 100f) * (float)laddersPercent.value / 2);
        int half = (numColumnas * numFilas) / 2;
        Nodo start;
        Nodo end;
        GameObject newLadder;
        int inicio, fin;

        for (int i = 0; i < laddersAmount; i++)
        {
            do
            {
                inicio = Random.Range(2, nodos.Length - numColumnas);
                fin = Random.Range(inicio + numColumnas, nodos.Length - 6);
                start = nodos[inicio];
                end = nodos[fin];
            } while (start.Indicador != null && (int)start.Indicador == 1);

            start.Indicador = (object)1;
            start.LigaIndicadora = end;
            newLadder = Instantiate(ladderPrefab);
            newLadder.GetComponent<LineRenderer>().SetPosition(0, new Vector3(start.casilla.transform.position.x, 0.3f, start.casilla.transform.position.z));
            newLadder.GetComponent<LineRenderer>().SetPosition(1, new Vector3(end.casilla.transform.position.x, 0.3f, end.casilla.transform.position.z));

        }
    }
}
