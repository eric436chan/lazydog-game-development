using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public static GameScore instance;

    public int miniGameScore;

    void Start()
    {
        miniGameScore = 0; 
    }

    void Update()
    {
        GameObject[] burgers = GameObject.FindGameObjectsWithTag("Burger");
        int numberOfBurgers = burgers.Length;

        if (miniGameScore >= numberOfBurgers)
        {
            //end mini game
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    int gameScore = 0;

    public void IncrementGameScore()
    {
        gameScore++;
        Debug.Log("Current game score: " + gameScore);
    }
}
