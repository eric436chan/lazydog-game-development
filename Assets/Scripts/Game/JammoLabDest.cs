using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammoLabDest : MonoBehaviour
{
    public Animator anim;
    private Vector3 currentDest;
    public int pivotPoint = 0;

    // Start is called before the first frame update
    private void Start()
    {
        pivotPoint = 0;
        gameObject.transform.position = new Vector3(-151.61f, 5.35f, -169.69f);
        currentDest = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jammo")
        {
            pivotPoint++;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (pivotPoint)
        {
            case 3:
                anim.SetBool("isWalking", false);
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;
                Destroy(FindObjectOfType<JammoLabAI>());
                Destroy(this);
                break;

            case 2:
                currentDest = new Vector3(-187.14f, 5.35f, -187.83f);

                break;

            case 1:
                currentDest = new Vector3(-181.5f, 5.35f, -174f);

                break;
        }
        gameObject.transform.position = currentDest;
    }
}