using System.Collections.Generic;
using UnityEngine;

public class InputToActivateAndDesactivate : MonoBehaviour
{
    public string axisNameToActivate;
    public string axisNameToDesactivate;
    public float margin = 0.05f;
    public GameObject objectToDesactivate;
    public bool inverseActivation;

    bool hasAxisToActivatePressed;
    void Update()
    {
        CheckObjectActivation();
    }
    void CheckObjectActivation()
    {
        if (objectToDesactivate == null)
        {
            return;
        }
        bool b = true;
        if (hasAxisToActivatePressed)
        {
            if (!Input.anyKey)
            {
                hasAxisToActivatePressed = !PlayerManager.instance.mainPlayer.isGrounded;
            }
            b = false;
        }
        else
        {
            if (IsAxisPressed(axisNameToActivate))
            {
                hasAxisToActivatePressed = true;
                b = false;
            }
            else if (!IsAxisPressed(axisNameToDesactivate))
            {
                b = false;
            }
        }
        if (b)
        {
            objectToDesactivate.SetActive(inverseActivation);
        }
        else
        {
            objectToDesactivate.SetActive(!inverseActivation);
        }
    }
    bool IsAxisPressed(string axisName)
    {
        if (axisName==null)
        {
            return false;
        }
        if (axisName=="")
        {
            return false;
        }
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
