using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToDesactivate : MonoBehaviour
{
    public string axisName;
    public float margin=0.05f;
    public GameObject objectToDesactivate;
    public bool inverseActivation;

    void Update()
    {
        if (axisName == null || axisName=="" || objectToDesactivate == null)
        {
            return;
        }
        if (IsAxisActivated())
        {
            objectToDesactivate.SetActive(inverseActivation);
        }
        else
        {
            objectToDesactivate.SetActive(!inverseActivation);
        }
    }

    bool IsAxisActivated()
    {        
        float f = Input.GetAxis(axisName);
        if (f - margin > 0)
        {
            return true;
        }
        if (f + margin < 0)
        {
            return true;
        }
        return false;
    }
}
