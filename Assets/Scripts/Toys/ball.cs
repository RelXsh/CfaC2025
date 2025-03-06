using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour, IInteractable
{ 
    public Rigidbody RB;
    public int kickCounter = 0;
    public static event Action onPlayed;

    public void Interact()
    {
        RB.AddForce(0, 10, 0, ForceMode.Impulse);
        Debug.Log(kickCounter);
        kickCounter++;
        if (kickCounter >= 5)
        {
            onPlayed?.Invoke();
            Destroy(this.gameObject);
        }
        
    }
}
