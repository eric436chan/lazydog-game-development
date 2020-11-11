using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyleLabDest : MonoBehaviour
{
    public Animator anim;
    private Vector3 currentDest;
    public int kylePivotPoint = 0;

    // Start is called before the first frame update
    private void Start()
    {
        kylePivotPoint = 0;
        gameObject.transform.position = new Vector3(-126.5f, 5.3f, -130f);
        currentDest = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kyle")
        {
            Debug.Log("Entered");
            kylePivotPoint++;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (kylePivotPoint)
        {
            case 3:
                FindObjectOfType<KyleDialogueTrigger>().enabled = true;
                Destroy(FindObjectOfType<KyleLabAI>());
                Destroy(this);
                break;

            case 2:
                currentDest = new Vector3(-107f, 5.3f, -150f);
                break;

            case 1:
                currentDest = new Vector3(-107f, 5.3f, -130f);

                break;
        }

        gameObject.transform.position = currentDest;
    }
}