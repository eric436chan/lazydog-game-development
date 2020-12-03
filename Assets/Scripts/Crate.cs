using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    private Rigidbody rbody;
    private GameObject controller;
    private GameScore script;
    private Text guiText;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameManager");
        script = controller.GetComponent<GameScore>();
        guiText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.CompareTag("Burger"))
        {
            script.miniGameScore += 1;
            guiText.text = script.miniGameScore + "";

        }
    }
    void OnTriggerExit(Collider coll)
    {

        if (coll.CompareTag("Burger"))
        {

            script.miniGameScore -= 1;
            guiText.text = script.miniGameScore + "";
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}