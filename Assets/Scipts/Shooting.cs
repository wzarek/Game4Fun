using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int AmmunitionInMagazine = 50;
    public int ReloadTimeSeconds = 3;

    private int _ammunitionLeft;
    private DateTime _reloadStartTime = DateTime.MinValue;
    private bool _reloading = false;

    private void Awake()
    {
        _ammunitionLeft = AmmunitionInMagazine;
    }

    private void Update()
    {
        if (_reloading && _reloadStartTime.AddSeconds(ReloadTimeSeconds) <= DateTime.Now)
        {
            _ammunitionLeft = AmmunitionInMagazine;
            _reloading = false;
        }
        else if (!_reloading && _ammunitionLeft <= 0)
        {
            _reloadStartTime = DateTime.Now;
            _reloading = true;
        }
        else if (!_reloading)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating(nameof(Fire), 0, 0.3f);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke(nameof(Fire));
            }
        }
    }

    void Fire()
    {
        if (_ammunitionLeft <= 0) CancelInvoke(nameof(Fire));
        Instantiate(BulletPrefab, transform.position, transform.rotation);
        _ammunitionLeft--;
    }

}
