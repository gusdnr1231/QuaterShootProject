using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.Animations.Rigging;

public class Player : MonoBehaviour
{
    public int maxHP;
    private int hp;
    public int HP => hp;
	[SerializeField] private ChangeScene changeScene;
	public int selectWeapon = 0;
	[Header("Gun")]
	private Weapon curWeapon;
	public List<Weapon> weapons;
	public List<Rig> gunRigs;
	
	public Light playerLight;


	private void Awake()
    {
        hp = maxHP;
    }

    private void Start()
	{
		SelectWeapon();
	}

    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
            changeScene.Changing(2);
        }
		int previousSelectWeapon = selectWeapon;
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if (selectWeapon >= weapons.Count - 1) selectWeapon = 0;
			else selectWeapon++;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectWeapon <= 0) selectWeapon = weapons.Count - 1;
			else selectWeapon--;
		}

		if (previousSelectWeapon != selectWeapon)
		{
			gunRigs[previousSelectWeapon].weight = 0;
			SelectWeapon();
		}
		if(curWeapon.CurAmmo == 0)
		{
			playerLight.color = Color.red;
		}
		else
		{
			playerLight.color = Color.white;
		}
	}

    public void GetDamaged()
    {
        if(hp <= 0) return;
		StartCoroutine(PlayerHit());
        hp--;
    }

	public void SelectWeapon()
	{
		gunRigs[selectWeapon].weight = 1;
		int num = 0;
		foreach (Weapon weapon in weapons)
		{
			if (num == selectWeapon) weapon.gameObject.SetActive(true);
			else weapon.gameObject.SetActive(false);
			num++;
		}
		curWeapon = weapons[selectWeapon];
		curWeapon.DrawGun();
	}

	IEnumerator PlayerHit()
	{
		playerLight.intensity = 1;
		yield return new WaitForSeconds(0.3f);
		playerLight.intensity = 2;
	}
}
