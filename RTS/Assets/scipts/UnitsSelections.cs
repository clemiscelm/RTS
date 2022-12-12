using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsSelections : MonoBehaviour
{
    public List<GameObject> unitsList = new List<GameObject>();
    public List<GameObject> unitsSelect = new List<GameObject>();
    public Material unitsMaterialSlected;
    public Material unitsMat;

    private static UnitsSelections _instance;
    public static UnitsSelections instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

    }

    public void clickSelect(GameObject unitToAdd)
    {
        deselectAll();
        unitsSelect.Add(unitToAdd);
        unitToAdd.GetComponent<MeshRenderer>().material = unitsMaterialSlected;
        unitToAdd.GetComponent<UnitMouvement>().enabled = true;
    }

    public void shiftToSelect(GameObject unitToAdd)
    {
        if(!unitsSelect.Contains(unitToAdd))
        {
            unitToAdd.GetComponent<MeshRenderer>().material = unitsMaterialSlected;
            unitsSelect.Add(unitToAdd);
            unitToAdd.GetComponent<UnitMouvement>().enabled = true;


        }
        else
        {
            unitToAdd.GetComponent<MeshRenderer>().material = unitsMat;
            unitToAdd.GetComponent<UnitMouvement>().enabled = false;

            unitsSelect.Remove(unitToAdd);


        }
    }

    public void dragSelect(GameObject unitToAdd)
    {
        if(!unitsSelect.Contains(unitToAdd))
        {
            unitsSelect.Add(unitToAdd);
            unitToAdd.GetComponent<MeshRenderer>().material = unitsMaterialSlected;
            unitToAdd.GetComponent<UnitMouvement>().enabled = true;

        }
    }

    public void deselectAll()
    {
        foreach(GameObject unitToRemove in unitsSelect)
        {
            unitToRemove.GetComponent<UnitMouvement>().enabled = false;
            unitToRemove.GetComponent<MeshRenderer>().material = unitsMat;
        }
        unitsSelect.Clear();
    }
    public void deselect(GameObject unitToDeselect)
    {

    }





}
