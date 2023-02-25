using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;




    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Fire", 0, 0.3f);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Fire");
        }

    }

    //private void OnEnable()
    //{


    //    InvokeRepeating("Fire", 0, 0.3f); // włączenie metody strzelania


    //}

    //private void OnDisable()
    //{
    //    CancelInvoke("Fire");// wyłączenie metody strzelania
    //}

    void Fire()
    {

        Instantiate(bulletPrefab, transform.position, transform.rotation);

    }

}
