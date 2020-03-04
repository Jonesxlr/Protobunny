using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMe : MonoBehaviour
{
    private float StartPosX,StartPosY,OriginX,OriginY;
    private bool dragging = false, isDocked = false;
    private Dock dock;
    public BunActions myAction;

    private void Start()
    {
        OriginX = transform.localPosition.x;
        OriginY = transform.localPosition.y;
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.localPosition = new Vector3(mousePos.x - StartPosX, mousePos.y - StartPosY, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            StartPosX = mousePos.x - transform.localPosition.x;
            StartPosY = mousePos.y - transform.localPosition.y;

            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
        if (isDocked)
        {
            transform.localPosition = dock.gameObject.transform.localPosition;
        }
        else
        {
            transform.localPosition = new Vector3(OriginX, OriginY, transform.localPosition.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dock")
        {
            dock = collision.gameObject.GetComponent<Dock>();
            if (dock.action == BunActions.Empty)
            {
                Debug.Log("Docking...");
                dock.action = myAction;
                dragging = false;
                isDocked = true;
                transform.localPosition = collision.gameObject.transform.localPosition;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Bye");
        if (collision.gameObject.tag == "Dock")
        {
            dock.action = BunActions.Empty;
            isDocked = false;
        }
    }
}
