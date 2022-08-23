using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TimeCountDown : MonoBehaviour
{
    public float timeDown;
    //[HideInInspector]
    public float remainingTime;
    public bool isCounting;

    public virtual void UpdateWhenTimeCount() { }
    public virtual void TimeUpHandle() { }
    public void SetAgainTimeCount()
    {
        isCounting = true;
        remainingTime = timeDown;
    }
    public virtual void Awake()
    {
        SetAgainTimeCount();
    }
    private void Update()
    {
        if (isCounting)
        {
            remainingTime -= Time.deltaTime;
            UpdateWhenTimeCount();
        }
        if (remainingTime < 0 && isCounting)
        {
            TimeUpHandle();
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