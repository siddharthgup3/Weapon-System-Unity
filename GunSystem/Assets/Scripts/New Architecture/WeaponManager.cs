﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private AllGuns allGuns;
    [SerializeField] private int typeIndex;
    [SerializeField] private int gunIndex;
    private BaseGunDefinition currentGun;
    [SerializeField] private EquippedGun equippedGun;

    private void Start()
    {
        if (typeIndex == 1)
            currentGun = allGuns.primGuns[gunIndex];
        else
            currentGun = allGuns.secoGuns[gunIndex];

        equippedGun.UpdateGun(currentGun);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            ChangeWeapon(true);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            ChangeWeapon(false);
    }

    private void ChangeWeapon(bool next)
    {
        // Use the bool next when meelee weapons added.
        if (typeIndex == 1) typeIndex = 2;
        else typeIndex = 1;

    }

    private void UpdateGun()
    {

    }
}
