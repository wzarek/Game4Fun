using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int AmmunitionInMagazine = 20;
    public int ReloadTimeSeconds = 3;
    public int ShootingCooldownMiliseconds = 100;

    private int _ammunitionLeft;
    private DateTime _reloadStartTime = DateTime.MinValue;
    private DateTime _lastTimeShot = DateTime.MinValue;
    private bool _reloading = false;
    private GameObject _ammunitionText;

    private void Awake()
    {
        _ammunitionLeft = AmmunitionInMagazine;
        _ammunitionText = GameObject.FindGameObjectWithTag("UIAmmo");

        SetAmmunitionText();
    }

    private void Update()
    {
        if (_reloading && _reloadStartTime.AddSeconds(ReloadTimeSeconds) <= DateTime.Now)
        {
            _ammunitionLeft = AmmunitionInMagazine;
            _reloading = false;
            SetAmmunitionText();
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
        }
        else
        {
            SetAmmunitionText();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke(nameof(Fire));
        }
    }

    private void Fire()
    {
        if (_ammunitionLeft <= 0) return;
        if (_lastTimeShot.AddMilliseconds(ShootingCooldownMiliseconds) > DateTime.Now) return;

        Instantiate(BulletPrefab, transform.position, transform.rotation);
        _ammunitionLeft--;
        _lastTimeShot = DateTime.Now;

        SetAmmunitionText();
    }

    private void SetAmmunitionText()
    {
        if (!_reloading)
        {
            _ammunitionText.GetComponent<TextMeshProUGUI>().text = $"{_ammunitionLeft}/{AmmunitionInMagazine}";
        }
        else
        {
            var loadingTime = Math.Ceiling(Math.Abs(DateTime.Now.Subtract(_reloadStartTime.AddSeconds(ReloadTimeSeconds)).TotalSeconds));
            _ammunitionText.GetComponent<TextMeshProUGUI>().text = $"Reloading [{loadingTime}s]";
        }
    }
}
