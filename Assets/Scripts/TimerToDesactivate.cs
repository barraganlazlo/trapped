using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToDesactivate : MonoBehaviour
{
    float actualTime;
    float lastTime;
    public float time = 1f;
    public GameObject desactivateAtTimerEnd;
    public bool inverseTimerActivation;
    public int resetNumberToActivate = 50;
    public GameObject activateOnResetNumber;
    public bool inverseResetActivation;
    public bool resetActivateOnEndTimer;
    int resetCounter =-1;
    bool end;
    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (end)
        {
            return;
        }
        if (Input.anyKey)
        {
            ResetTimer();
        }
        actualTime += Time.deltaTime;
        if (actualTime>time && lastTime<time)
        {
            desactivateAtTimerEnd.SetActive(inverseTimerActivation);
            if (resetActivateOnEndTimer)
            {
                activateOnResetNumber.SetActive(!inverseResetActivation);
            }
            end = true;
        }
        lastTime=actualTime;
    }
    void ResetTimer()
    {
        resetCounter += 1;
        if (resetCounter> resetNumberToActivate)
        {
            activateOnResetNumber.SetActive(!inverseResetActivation);
        }
        desactivateAtTimerEnd.SetActive(!inverseTimerActivation);
        actualTime = 0;
        lastTime = 0;
    }
}
