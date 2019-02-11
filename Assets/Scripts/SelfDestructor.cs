using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    public float timeToDestruct=0.1f;

    void Awake()
    {

        Destroy(gameObject,timeToDestruct);
    }
}
