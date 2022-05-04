using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam;
    [SerializeField] MouseLook controller;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    [SerializeField] float zoomedInSensitivity = 1f;
    [SerializeField] float zoomedOutSensitivity = 2f;

   
   

    // Update is called once per frame
    void Update()
    {
        ScopeZoom();
    }

    void ScopeZoom()
    {


        if (Input.GetMouseButtonDown(1))
        {
            ZoomIn();

        }
        else if (Input.GetMouseButtonUp(1))
        {
            ZoomOut();
        }
            
    }

    public void ZoomOut()
    {
            cam.fieldOfView = zoomedOutFOV;
            controller.XSensitivity = zoomedOutSensitivity;
            controller.YSensitivity = zoomedOutSensitivity;
        
    }

    public void ZoomIn()
    {
    cam.fieldOfView = zoomedInFOV;
    controller.XSensitivity = zoomedInSensitivity;
    controller.YSensitivity = zoomedInSensitivity;
    }

    private void OnDisable()
    {
        ZoomOut();
    }
}
