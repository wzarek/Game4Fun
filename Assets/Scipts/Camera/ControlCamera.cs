using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    private GameObject _zoomCamera;
    private GameObject _normalCamera;

    public int zoomFov = 20;
    public int nonZoomFov = 40;
 
  
 



    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire2"))
        {
          
            _normalCamera.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = zoomFov;
        }
        if(Input.GetButtonUp("Fire2"))
        {

            _normalCamera.GetComponent<CinemachineFreeLook>().m_Lens.FieldOfView = nonZoomFov;

        }
    }

    private void Awake()
    {
        _zoomCamera = GameObject.Find("Player/Camera/ThirdPersonCameraZoom");
        _normalCamera = GameObject.Find("Player/Camera/ThirdPersonCamera");

    }
}
