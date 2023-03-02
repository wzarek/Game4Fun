using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    private float distance;
    public Transform Target;
    public float RotationSpeed = 20;
    
    
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Update is called once per frame
    void Update()
    {
        Vector3 aboveGround = new Vector3(0, .0001f, .0001f);
        Vector3 mousePos = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
       // distance = Vector3.Distance(player.transform.position, cam.transform.position);
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
          //  Debug.Log(hit.transform.gameObject);
            hit.point += aboveGround;
           // transform.rotation = hit.transform.rotation;
            _direction = (hit.transform.position - transform.position).normalized;
            if(_direction != Vector3.zero)
            {
                _lookRotation = Quaternion.LookRotation(_direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
            }

            

        }
        
           
         


       
    }

    void ReycastObject()
    {

        distance = Vector3.Distance(player.transform.position, cam.transform.position);
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Debug.DrawRay(ray.origin + cam.transform.forward * distance, ray.direction * 1, Color.yellow);
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.red);
        Debug.DrawLine(cam.transform.position, player.transform.position, Color.blue);
    }


}
