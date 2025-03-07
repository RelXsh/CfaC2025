using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour, IInteractable
{
    public appleManager appleManager;

    void Start()
    {
        appleManager = GameObject.Find("AppleManager").GetComponent<appleManager>();
        Debug.Log(1);
    }
    public void Interact()
    {
        appleManager.EatApple();
        Destroy(this.gameObject);
    }
}
