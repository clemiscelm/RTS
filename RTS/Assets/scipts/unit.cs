using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitsSelections.instance.unitsList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        UnitsSelections.instance.unitsList.Remove(this.gameObject);
    }
}
