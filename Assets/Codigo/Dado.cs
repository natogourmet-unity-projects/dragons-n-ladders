using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour
{

    [SerializeField]
    public Sprite[] diceSides;

    private Image rend;
    public int whosTurn = 1;
    private bool coroutineAllowed = true;
    private bool gotSix = false;


    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Image>();
        rend.sprite = diceSides[5];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Clicked()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    public IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 10; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
  
        Jugabilidad.diceSideThrown = randomDiceSide + 1;
        Jugabilidad.MovePlayer(whosTurn == 1 ? 1 : 0);
        if (!gotSix && randomDiceSide == 5) gotSix = true;
        else
        {
            whosTurn *= -1;
            gotSix = false;
        }

        coroutineAllowed = true;
    }
}
