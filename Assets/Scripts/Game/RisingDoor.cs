using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RisingDoor : MonoBehaviour
{
    private Animator anim;
    public Transform newPos;
    public GameObject jammo;
    public bool elevStart;
    private bool hasRider;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (PuzzleManager.instance.isPuzzleTwoFinished)
        {
            transform.position = Vector3.Lerp(transform.position, newPos.position, 0.3f * Time.deltaTime);
        }

        if (jammo.transform.position.y >= 15.45f)
        {
            jammo.transform.parent = null;
            jammo.GetComponent<NavMeshAgent>().enabled = true;
            FindObjectOfType<AfterElevDest>().enabled = true;
            FindObjectOfType<JammoAfterElevAI>().enabled = true;
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jammo")
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.SetParent(gameObject.transform);
        }
    }
}