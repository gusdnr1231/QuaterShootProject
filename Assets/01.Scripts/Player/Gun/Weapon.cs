using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using Core;

public class Weapon : MonoBehaviour
{
	[Header("Weapon Objects")]
	[SerializeField] private GameObject muzzleFlash;
	[SerializeField] private Transform shootPosition;
	[SerializeField] private Transform baseTransform;
	public GameObject bulletType;

	[SerializeField] WeaponSO weaponType;
	private int curAmmo;
	public int CurAmmo => curAmmo;

	bool isShoot = false;

	private void Awake()
	{
		DrawGun();
	}

	private void FixedUpdate()
	{
		if(Input.GetMouseButton(0) && isShoot == false) ShootGun();
	}

	public void DrawGun()
	{
		isShoot = false;
		//muzzleFlash.SetActive(false);
		curAmmo = weaponType.maxAmmo;
	}

	public void ShootGun()
	{
		Debug.Log(curAmmo);
		if (curAmmo > 0)
		{
			switch (weaponType.GunType)
			{
				case GunType.HandGun:
				case GunType.Sniper:
					StartCoroutine(Shoot());
					break;
				case GunType.ShotGun:
					break;
			}
			curAmmo--;
		}
	}

	public void UpdateGun()
	{
		throw new System.NotImplementedException();
	}
	
	IEnumerator Shoot()
	{
		isShoot = true;
		//muzzleFlash.SetActive(true);
		GameObject intantBullet = Instantiate(bulletType, shootPosition.position, baseTransform.rotation);
		Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
		Bullet bullet = intantBullet.GetComponent<Bullet>();
		bulletRigid.velocity = Vector3.forward * bullet.speed;
		yield return new WaitForSeconds(weaponType.shootDelay);
		//muzzleFlash.SetActive(false);
		isShoot = false;
	}
}
