using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Weapon : MonoBehaviour
{
	[Header("Weapon Objects")]
	[SerializeField] private GameObject muzzleFlash;
	[SerializeField] private Transform shootPosition;
	[SerializeField] private Transform baseTransform;
	public GameObject bulletType;

	[SerializeField]
	[Range(5,10)]
	int shotgunBullets;

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
		muzzleFlash.SetActive(false);
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
					StartCoroutine(ShotGunShoot());
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
		muzzleFlash.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		muzzleFlash.SetActive(false);
		GameObject intantBullet = Instantiate(bulletType, shootPosition.position, baseTransform.rotation);
		Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
		Bullet bullet = intantBullet.GetComponent<Bullet>();
		bulletRigid.velocity = transform.rotation * Vector3.forward * bullet.speed;
		yield return new WaitForSeconds(weaponType.shootDelay);
		isShoot = false;
	}

	IEnumerator ShotGunShoot()
	{
		isShoot = true;
		muzzleFlash.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		muzzleFlash.SetActive(false);
		for (int i = 0; i < shotgunBullets; i++)
		{
			Quaternion rot = Quaternion.Euler(baseTransform.rotation.x, baseTransform.rotation.y + Random.Range(-10, 11), baseTransform.rotation.z);
			GameObject intantBullet = Instantiate(bulletType, shootPosition.position, rot);
			Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
			Bullet bullet = intantBullet.GetComponent<Bullet>();
			bulletRigid.velocity = baseTransform.rotation * rot * Vector3.forward * bullet.speed;
		}
		yield return new WaitForSeconds(weaponType.shootDelay);
		isShoot = false;
	}
}
