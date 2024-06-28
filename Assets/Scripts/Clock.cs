using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot;

    [SerializeField]
    Transform minutesPivot;

    [SerializeField]
    Transform secondsPivot;

    const float hoursToDegrees = -1f * 360f / 12f;
    const float minutesToDegrees = -1f * 360f / 60f;
    const float secondsToDegrees = -1f * 360f / 60f;

    void Update()
    {
        //Debug.Log(DateTime.Now);
        //hoursPivot.localRotation = Quaternion.Euler(0, 0, -30);
        var time = DateTime.Now.TimeOfDay;

        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * DateTime.Now.Second);
    }
}
