using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitDrag : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    RectTransform boxVisual;

    Rect selectionBox;
    Vector2 startPoint;
    Vector2 endPoint;

    private void Start()
    {
        cam = Camera.main;
        startPoint = Vector2.zero;
        endPoint = Vector2.zero;
        DrawVisual();
    }


    private void Update()
    {
        //whene click
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
            selectionBox = new Rect();

        }
        //whene drag
        if (Input.GetMouseButton(0))
        {
            endPoint = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        //whene release;
        if(Input.GetMouseButtonUp(0))
        {
            SelectsUnits();
            startPoint = Vector2.zero;
            endPoint = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPoint;
        Vector2 boxend = endPoint;
        Vector2 boxCenter = (boxend + boxStart)/2;

        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxend.x), Mathf.Abs(boxStart.y - boxend.y));
        boxVisual.sizeDelta = boxSize;
    }


    void DrawSelection()
    {
        if(Input.mousePosition.x < startPoint.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPoint.x;  
        }
        else
        {
            selectionBox.xMin = startPoint.x;   
            selectionBox.xMax = Input.mousePosition.x;
        }


        if (Input.mousePosition.y < startPoint.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPoint.y;
        }
        else
        {
            selectionBox.yMin = startPoint.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }


    void SelectsUnits()
    {
        foreach(var unit in UnitsSelections.instance.unitsList)
        {
            if(selectionBox.Contains(cam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitsSelections.instance.dragSelect(unit);
            }
        }
    }

}
