using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInit : MonoBehaviour
{
    public float yValue;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x, yValue, gameObject.transform.localPosition.z);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}