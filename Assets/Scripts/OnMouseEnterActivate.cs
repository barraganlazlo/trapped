using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnMouseEnterActivate : MonoBehaviour
{
    public GameObject objectToActivate;
    public bool inverseActivation;

    private void OnMouseEnter()
    {
        objectToActivate.SetActive(!inverseActivation);
    }
}
