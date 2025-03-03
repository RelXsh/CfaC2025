using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitcher : MonoBehaviour, IInteractable
{
    public Material nightSkybox;
    public Material daySkybox;
    private Material skyboxMaterial;


    public void Interact()
    {
        Debug.Log(1);
        if (skyboxMaterial == nightSkybox)
        {
            skyboxMaterial = daySkybox;
        }
        else
        {
            skyboxMaterial = nightSkybox;
        }

        RenderSettings.skybox = skyboxMaterial;
    }
}
