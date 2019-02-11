using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnTriggerActivate : MonoBehaviour
{
    public GameObject objectToActivate; 
    public bool inverseActivation;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            objectToActivate.SetActive(!inverseActivation);
        }
    }
}
