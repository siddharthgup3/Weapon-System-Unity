﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedGun : MonoBehaviour
{
    [SerializeField] public GunDefinition[] allGuns;
    public GunDefinition currentGun;
    public int currentGunIndex = 1;

    public void Start()
    {
        currentGun = allGuns[currentGunIndex];
    }

    public void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            NextWeapon();
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            PreviousWeapon();
    }

    public void UpdateGun(int updatedGunIndex)
    {
        for (int i = 0; i < allGuns.Length; i++)
        {
            allGuns[i].gunModel.SetActive(false);
        }
        allGuns[currentGunIndex].gunModel.SetActive(true);
    }

    public void NextWeapon()
    {
        currentGunIndex++;
        if (currentGunIndex > allGuns.Length)
            currentGunIndex = 0;

        UpdateGun(currentGunIndex);

    }

    public void PreviousWeapon()
    {
        currentGunIndex--;
        if (currentGunIndex <= 0)
            currentGunIndex = allGuns.Length;

        UpdateGun(currentGunIndex);
    }

}
