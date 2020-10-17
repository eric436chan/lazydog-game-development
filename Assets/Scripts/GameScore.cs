using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public static GameScore instance;

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
