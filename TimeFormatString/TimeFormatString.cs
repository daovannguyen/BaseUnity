using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFormatString
{
    private float second;

    public TimeFormatString(float second)
    {
        this.second = second;
    }

    public string GetFormatHMMSS()
    {
        TimeSpan t = TimeSpan.FromSeconds(second);
        return string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Hours,
                t.Minutes,
                t.Seconds);
    }
    // chỉ xảy ra khi số second nhỏ hơn 1 giờ
    public string GetFormatMMSS()
    {
        if (second < 60 * 60)
        {
            TimeSpan t = TimeSpan.FromSeconds(second);
            return string.Format("{0:D2}:{1:D2}",
                    t.Minutes,
                    t.Seconds);
        }
        return "Time over 1 hour";
    }
}
