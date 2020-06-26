﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public AllGuns allGuns;
    [SerializeField] private int typeIndex = 1;
    [SerializeField] private int gunIndex = 0;
    private BaseGunDefinition currentGun;
    [SerializeField]private EquippedGun equippedGun;

    public void Awake()
    {
        if (typeIndex == 1)
            currentGun = allGuns.primaryGuns[gunIndex];
        else
            currentGun = allGuns.secondaryGuns[gunIndex];

        equippedGun.UpdateGun(currentGun);
        //StartCoroutine(equippedGun.GunChange(currentGun, 0));
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            ChangeWeapon(true);
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            ChangeWeapon(false);
    }

    private void ChangeWeapon(bool next)
    {
        if (next) typeIndex++;
        else typeIndex--;

        if (typeIndex > 2) typeIndex = 1;
        else if (typeIndex <= 0) typeIndex = 2;

        if (typeIndex == 1)
            currentGun = allGuns.primaryGuns[gunIndex];
        else
            currentGun = allGuns.secondaryGuns[gunIndex];

        var timer = typeIndex == 1 ? 2 : 1;
        StartCoroutine(equippedGun.GunChange(currentGun, timer));
    }
}
