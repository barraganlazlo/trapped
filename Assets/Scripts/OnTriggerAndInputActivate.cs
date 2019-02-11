using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnTriggerAndInputActivate : MonoBehaviour
{
    public GameObject ToActivate;
    public string axisName;
    public float margin = 0.05f;
    public bool inverseActivation;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (IsAxisActivated())
            {
                ToActivate.SetActive(!inverseActivation);
            }
        }
    }
    bool IsAxisActivated()
    {
        if (axisName==null ||axisName=="")
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
