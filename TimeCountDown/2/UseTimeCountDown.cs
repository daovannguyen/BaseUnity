using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimeCountDown))]
public class UseTimeCountDown : MonoBehaviour
{
    TimeCountDown timeCountDown;
    private void Awake()
    {
        timeCountDown = GetComponent<TimeCountDown>();
        timeCountDown.timeUpHandle.AddListener(SayTimeUp);
        timeCountDown.updateWhenTimeCount.AddListener(SayRemainingTime);
        timeCountDown.SetAgainTimeCount();
    }

    private void SayRemainingTime()
    {
        Debug.Log(timeCountDown.remainingTime);
    }

    private void SayTimeUp()
    {
        Debug.Log("Hết giờ rồi bạn ơi");
    }

}
