using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class TimeCountDown : MonoBehaviour
{
    public float timeDown;
    //[HideInInspector]
    public float remainingTime;
    public bool isCounting;
    [HideInInspector]
    public UnityEvent timeUpHandle;
    [HideInInspector]
    public UnityEvent updateWhenTimeCount;

    public void SetAgainTimeCount()
    {
        enabled = true;
        isCounting = true;
        remainingTime = timeDown;
    }
    private void Update()
    {
        if (isCounting)
        {
            remainingTime -= Time.deltaTime;
            updateWhenTimeCount.Invoke();
        }
        if (remainingTime < 0 && isCounting)
        {
            enabled = false;
            timeUpHandle.Invoke();
            isCounting = false;
        }
    }
    public void FreezeCount()
    {
        isCounting = false;
    }
    public void UnfreezeCount()
    {
        isCounting = true;
    }
    public void AddMoreTimeCount(int moreTime)
    {
        remainingTime += moreTime;
    }
}