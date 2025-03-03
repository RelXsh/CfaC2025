using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    public Material[] skyboxes;
    public int timeIndex;
    // time indexes: 0 - night, 1 - morning, 2 - day, 3 - evening

    public void SetTime(int desiredTimeIndex)
    {
        if (timeIndex != desiredTimeIndex)
        {
            timeIndex = desiredTimeIndex;
            RenderSettings.skybox = skyboxes[timeIndex];
        }
    }
}
