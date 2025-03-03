using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour, IInteractable
{ 
    public Rigidbody RB;
    

    public void Interact()
    {
        RB.AddForce(0, 10, 0, ForceMode.Impulse);
        Debug.Log(0);
    }
}
