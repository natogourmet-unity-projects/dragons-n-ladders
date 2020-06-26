using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugabilidad : MonoBehaviour
{

    public GameObject _player1, _player2, _victory;
    public Text _player1Turn, _player2Turn;

    public static GameObject player1, player2, victory;
    public static bool gameOver = false;
    public static int diceSideThrown = 0;
    public static bool vsMachine = false;
    public static Text player1turn;
    public static Text player2turn;

    // Use this for initialization
    void Start()
    {
        player1 = _player1;
        player2 = _player2;
        victory = _victory;
        player1turn = _player1Turn;
        player2turn = _player2Turn;
        player1.GetComponent<Jugador>().puedeMover = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void GameOver()
    {
        gameOver = true;
        if (player1.GetComponent<Jugador>().actual == LDL.ultimo)
        {
            victory.GetComponent<Text>().text = "JUGADOR 1 ES EL GANADOR";
        }
        else
        {
            victory.GetComponent<Text>().text = "JUGADOR 2 ES EL GANADOR";
        }
        victory.SetActive(true);
        GameObject.FindGameObjectWithTag("Dado").GetComponent<Button>().interactable = false;
    }

    public static void MovePlayer(int player)
    {
        if (player == 1)
        {
            int movesLeft = MovementsTillEnd(player1.GetComponent<Jugador>());
            if (movesLeft == 0 || (movesLeft > 0 && diceSideThrown == movesLeft))
            {
                player1turn.fontStyle = FontStyle.Bold;
                player1turn.color = new Color(0, 0, 150);
                player2turn.fontStyle = FontStyle.Normal;
                player2turn.color = new Color(0, 0, 0);


                player1.GetComponent<Jugador>().destino = player1.GetComponent<Jugador>().actual.LigaConsecutiva;
                player1.GetComponent<Jugador>().posicion = 1;
                player1.GetComponent<Jugador>().puedeMover = true;
                FollowPlayer.player = player1.transform;
            }

        }
        else
        {
            int movesLeft = MovementsTillEnd(player2.GetComponent<Jugador>());
            if (movesLeft == 0 || (movesLeft > 0 && diceSideThrown == movesLeft))
            {
                player2turn.fontStyle = FontStyle.Bold;
                player2turn.color = new Color(0, 0, 150);
                player1turn.fontStyle = FontStyle.Normal;
                player1turn.color = new Color(0, 0, 0);

                player2.GetComponent<Jugador>().destino = player2.GetComponent<Jugador>().actual.LigaConsecutiva;
                player2.GetComponent<Jugador>().posicion = 1;
                player2.GetComponent<Jugador>().puedeMover = true;
                FollowPlayer.player = player2.transform;
            }
        }

    }

    public static int MovementsTillEnd(Jugador player)
    {
        Nodo p = player.actual;
        for (int i = 1; i <= 6; i++)
        {
            if (p.LigaConsecutiva == LDL.ultimo) return i;
            p = p.LigaConsecutiva;
        }
        return 0;
    }
}
