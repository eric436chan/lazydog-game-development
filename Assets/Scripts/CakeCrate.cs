using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeCrate : MonoBehaviour
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
        guiText = GameObject.Find("CakeScore").GetComponent<Text>();
        //Debug.Log(script.cake);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        rbody = coll.gameObject.GetComponent<Rigidbody>();
        Debug.Log(script.cake);
        if (coll.CompareTag("Cake"))
        {
            script.cake += 1;
            guiText.text = script.cake + "";
            Debug.Log(script.cake);
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

        if (coll.CompareTag("Cake"))
        {

            script.cake -= 1;
            guiText.text = script.cake + "";
            Debug.Log(script.cake);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}