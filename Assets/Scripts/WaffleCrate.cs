using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaffleCrate : MonoBehaviour
{
    private Rigidbody rbody;
    private GameObject controller;
    private GameScore script;
    private Text guiText;

    private

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameManager");
        script = controller.GetComponent<GameScore>();
        guiText = GameObject.Find("WaffleScore").GetComponent<Text>();
        //Debug.Log(script.waffles);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        rbody = coll.gameObject.GetComponent<Rigidbody>();
        //Debug.Log(script.waffles);
        if (coll.CompareTag("Waffle"))
        {
            script.waffles += 1;
            guiText.text = script.waffles + "";
            //Debug.Log(script.waffles);
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

        if (coll.CompareTag("Waffle"))
        {

            script.waffles -= 1;
            guiText.text = script.waffles + "";
            //Debug.Log(script.waffles);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}