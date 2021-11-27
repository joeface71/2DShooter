using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; }

    [field: SerializeField]
    [field: Range(0, 100)]
    public int AmmoCapacity { get; set; } = 100;

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = .1f;

    [field: SerializeField]
    [field: Range(0f, 10f)]
    public float SpreadAngle { get; set; } = 5f;

    [SerializeField] private bool multiBulletShoot = false;

    [Range(1, 10)]
    [SerializeField] private int bulletCount = 0;

    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShoot)
        {
            return bulletCount;
        }
        return 1;
    }
}