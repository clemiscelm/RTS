using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitClick : MonoBehaviour
{
    public Camera cam;

    public LayerMask clickable;
    public LayerMask ground;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    UnitsSelections.instance.shiftToSelect(hit.collider.gameObject);

                }
                else
                {
                    UnitsSelections.instance.clickSelect(hit.collider.gameObject);
                }


            }
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                    UnitsSelections.instance.deselectAll();
            }
        }
    }
}
