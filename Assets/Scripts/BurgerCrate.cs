using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerCrate : MonoBehaviour
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
        Debug.Log(script.burgers);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        rbody = coll.gameObject.GetComponent<Rigidbody>();
        Debug.Log(script.burgers);
        if (coll.CompareTag("Burger"))
        {
            script.burgers += 1;
            guiText.text = script.burgers + "";
            Debug.Log(script.burgers);
        }
        else
        {
            GetComponent<Collider>().isTrigger = false;
            rbody.AddForce(new Vector3(transform.position.x * 5.0f, -transform.position.y * 5.0f, transform.position.z * 5.0f));

        }
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerExit(Collider coll)
    {

        if (coll.CompareTag("Burger"))
        {

            script.burgers -= 1;
            guiText.text = script.burgers + "";
            Debug.Log(script.burgers);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}