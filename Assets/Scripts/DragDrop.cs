using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour
{
    //position properties
    private float zPos;
    private Vector3 offset;
    private bool dragging;

    private Rigidbody rbody;

    //Inspector variables

    [SerializeField] public Camera mainCamera;
    [SerializeField] public UnityEvent OnBeginDrag;
    [SerializeField] public UnityEvent OnEndDrag;

    [SerializeField] float speed = 7;

    //Unity function
    void Start()
    {
        zPos = mainCamera.WorldToScreenPoint(transform.position).z;
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPos);
            transform.position = mainCamera.ScreenToWorldPoint(position + new Vector3(offset.x, offset.y));
            //rbody.AddForce(position * speed);
        }

        
    }

    void OnMouseDown()
    {
        if (!dragging)
        {
            BeginDrag();
        }


        //Destroy(gameObject);

    }

    void OnMouseUp()
    {
        EndDrag();
    }

    //User input 
    void BeginDrag()
    {
        OnBeginDrag.Invoke();
        dragging = true;
        offset = mainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    void EndDrag()
    {
        OnEndDrag.Invoke();
        dragging = false;
    }
}
