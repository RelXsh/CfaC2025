using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedNightSkipper : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public DayTimeManager dayTimeManager;
    public static event Action onSleep;
    public void Interact() 
    { 
        if (dayTimeManager.timeIndex==3)
        {
            onSleep?.Invoke();
            dayTimeManager.SetTime(0);
        }
    }
}
