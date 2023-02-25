using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    private GameObject _zoomCamera;
    private GameObject _normalCamera;


    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire2"))
        {
          
            _zoomCamera.GetComponent<CinemachineFreeLook>().Priority = 11;
        }
        if(Input.GetButtonUp("Fire2"))
        {
          
            _zoomCamera.GetComponent<CinemachineFreeLook>().Priority = 9;
           
        }
    }

    private void Awake()
    {
        _zoomCamera = GameObject.Find("Player/Camera/ThirdPersonCameraZoom");
        _normalCamera = GameObject.Find("Player/Camera/ThirdPersonCamera");

    }
}
