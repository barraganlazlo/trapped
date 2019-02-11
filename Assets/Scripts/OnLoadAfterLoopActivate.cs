using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadAfterLoopActivate : MonoBehaviour
{

    public GameObject objectToActivate;
    public bool inverseActivation;

    private void Awake()
    {
        if (LevelManager.instance.HasLooped()) {
            objectToActivate.SetActive(!inverseActivation);
        }
    }
}
