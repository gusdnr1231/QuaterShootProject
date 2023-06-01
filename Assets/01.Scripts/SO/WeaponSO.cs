using Core;
using UnityEngine;

[CreateAssetMenu (menuName = "SO/WeaponData")]
public class WeaponSO : ScriptableObject
{
	public GunType GunType;
	public int damage;
	
	[Range(1f, 2f)]
	public float criticalDamage;
	public int maxAmmo;

	public float shootDelay;
	public float reloadDelay;
}
