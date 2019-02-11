using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnCollisionActivate : MonoBehaviour
{
    public GameObject objectToActivate;
    public bool inverseActivation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToActivate.SetActive(!inverseActivation);
        }
    }
}
