using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public static GameScore instance;

    public int burgers;
    public int waffles;
    public int cake;

    void Start()
    {
        burgers = 0;
        cake = 0;
        waffles = 0;
    }

    void Update()
    {
        GameObject[] allBurgers = GameObject.FindGameObjectsWithTag("Burger");
        int numOfBurgers = allBurgers.Length;

        GameObject[] allCake = GameObject.FindGameObjectsWithTag("Cake");
        int numOfCake = allCake.Length;

        GameObject[] allWaffles = GameObject.FindGameObjectsWithTag("Waffle");
        int numOfWaffles = allWaffles.Length;

        if (burgers >= numOfBurgers && cake >= numOfCake && waffles >= numOfWaffles)
        {
            //end mini game
        }
    }

    public void IncrementGameScore()
    {

    }

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

}
