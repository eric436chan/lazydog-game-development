using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;

    public int burgers;
    public int waffles;
    public int cake;

    private Text burgerTotal;
    private Text waffleTotal;
    private Text cakeTotal;

    private Text burgerScore;
    private Text waffleScore;
    private Text cakeScore;

    private int numOfBurgers;
    private int numOfWaffles;
    private int numOfCake;

    private void Start()
    {
        burgers = 0;
        cake = 0;
        waffles = 0;

        burgerTotal = GameObject.Find("BurgerTotal").GetComponent<Text>();
        waffleTotal = GameObject.Find("WaffleTotal").GetComponent<Text>();
        cakeTotal = GameObject.Find("CakeTotal").GetComponent<Text>();


        burgerScore = GameObject.Find("BurgerScore").GetComponent<Text>();
        waffleScore = GameObject.Find("WaffleScore").GetComponent<Text>();
        cakeScore = GameObject.Find("CakeScore").GetComponent<Text>();

        burgerScore.text = "" + burgers;
        waffleScore.text = "" + waffles;
        cakeScore.text = "" + cake;

        GameObject[] allBurgers = GameObject.FindGameObjectsWithTag("Burger");
        numOfBurgers = allBurgers.Length;

        GameObject[] allWaffles = GameObject.FindGameObjectsWithTag("Waffle");
        numOfWaffles = allWaffles.Length;

        GameObject[] allCake = GameObject.FindGameObjectsWithTag("Cake");
        numOfCake = allCake.Length;

        burgerTotal.text = "/" + numOfBurgers;
        waffleTotal.text = "/" + numOfWaffles;
        cakeTotal.text = "/" + numOfCake;

    }

    private void Update()
    {
        

        if (burgers >= numOfBurgers && cake >= numOfCake && waffles >= numOfWaffles)
        {
            //end mini game
            KyleDialogueManager.instance.dialogueNumber = 5;
            Destroy(this);
        }
    }

    public void IncrementGameScore()
    {
    }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
}