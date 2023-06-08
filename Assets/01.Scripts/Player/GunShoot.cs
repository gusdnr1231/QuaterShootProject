using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlash;
    private Transform shootPosition;

    private void Awake()
    {
        muzzleFlash.SetActive(false);
        shootPosition = transform.Find("ShootPosition").GetComponentInChildren<Transform>();
    }


}
