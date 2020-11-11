using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorTrigger : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Animator fadeAnim;
    public TextMeshProUGUI fadingText;
    public BoxCollider box;
    public Item key;
    private float dist;
    public bool isOpen = false;

    // Start is called before the first frame update

    private void Start()
    {
        box = gameObject.GetComponent<BoxCollider>();
    }

    public void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);
    }

    private void OnMouseOver()
    {
        if (dist <= 5f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Inventory.instance.inventory.Contains(key))
                {
                    isOpen = !isOpen;
                    anim.SetBool("IsOpen", isOpen);
                    box.enabled = !isOpen;
                }
                else
                {
                    fadingText.text = "Door is locked...";
                    fadeAnim.Play("Out");
                }
            }
        }
    }
}