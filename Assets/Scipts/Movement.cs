using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float PlayerSpeed = .5f;
    public float PlayerRotationSpeed = 150f;
    public float PlayerJumpForce = 500f;

    private Rigidbody currentRigidbody;
    private bool _isTurned = false;

    private void Awake()
    {
        currentRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

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
       
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentRigidbody.AddForce(Vector3.up * PlayerJumpForce * 1.5f);

            Vector3 vel = currentRigidbody.velocity;
            if (currentRigidbody.velocity.y < 0.5f)
            {
                currentRigidbody.velocity = new Vector3(vel.x, 0, vel.z);
            }
            else if (currentRigidbody.velocity.y > 0)
            {
                currentRigidbody.velocity = new Vector3(vel.x, vel.y / 2, vel.z);
            }
        }
    }
}
