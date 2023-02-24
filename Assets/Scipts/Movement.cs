using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float PlayerSpeed=.5f;
    public float PlayerRotationSpeed=150f;
    private bool _isTurned = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            PlayerSpeed = PlayerSpeed * 0.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerSpeed = 2f;
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime *PlayerSpeed);
           
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (_isTurned == false)
            {
                transform.Rotate(0, 180, 0);
                _isTurned = true;
            }

             transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _isTurned = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(0, -(PlayerRotationSpeed * Time.deltaTime), 0);
            transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed*0.3f);

        }
      
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, PlayerRotationSpeed * Time.deltaTime, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed*0.3f);

        }
       
       

    }
}
