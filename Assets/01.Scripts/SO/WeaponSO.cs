using Core;
using UnityEngine;

[CreateAssetMenu (menuName = "SO/WeaponData")]
public class WeaponSO : ScriptableObject
{
	public GunType GunType;
	public int maxAmmo;
	public float shootDelay;
}
