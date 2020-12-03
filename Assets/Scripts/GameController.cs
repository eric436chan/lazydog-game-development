using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] burgers = GameObject.FindGameObjectsWithTag("Burger");
        int numberOfBurgers = burgers.Length;
        if ( score >= numberOfBurgers)
        {
            //End Game
        }
    }

    int getScore()
    {
        return score;
    }
    void setScore(int i)
    {
        score = i;
    }
}
