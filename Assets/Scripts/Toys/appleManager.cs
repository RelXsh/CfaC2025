using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleManager : MonoBehaviour
{
    public Transform[] appleLoc;
    public int applesEaten;
    public GameObject applePrefab;
    public static event Action onEaten;
    public audioManaer audioManager;

    public void SpawnApples(Transform[] appleLoc)
    {
        //for each transform in the array
        foreach (Transform loc in appleLoc)
        {
            //spawn an aple at one of the transform.positions in the array
            Instantiate(applePrefab, loc.position, Quaternion.identity);
        }
    }

    public void EatApple()
    {
        audioManager.PlaySFX(audioManager.apple);
        applesEaten++;
        if (applesEaten >= 5)
        {
            onEaten?.Invoke();
        }
        print(applesEaten);
    }
}
