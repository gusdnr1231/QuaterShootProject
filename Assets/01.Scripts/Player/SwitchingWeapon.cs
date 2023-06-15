using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapon : MonoBehaviour
{
    public int selectWeapon = 0;
    [Header("Gun")]
    public GunType gunType;
    public Weapon curWeapon;
    public List<Weapon> weapons;

    private void Awake()
    {
        gunType = GunType.HandGun;
    }

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectWeapon = selectWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectWeapon >= transform.childCount - 1) selectWeapon = 0;
            else selectWeapon++;
        }

		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectWeapon <= 0) selectWeapon = transform.childCount - 1;
			else selectWeapon--;
		}

        if(previousSelectWeapon != selectWeapon)
        {
            SelectWeapon();
        }
	}

    public void SelectWeapon()
    {
        int num = 0;
        foreach (Transform weapon in transform)
        {
            if(num == selectWeapon) weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            num++;
        }
        switch (selectWeapon)
        {
            case 0: gunType = GunType.HandGun; break;
            case 1: gunType = GunType.HandGun; break;
            case 2: gunType = GunType.HandGun; break;
        }
        curWeapon = weapons[selectWeapon];
    }
}
