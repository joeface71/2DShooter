using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletDataSO", menuName = "Weapons/BulletData", order = 0)]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField]
    public GameObject bulletPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 100)]
    public float BulletSpeed { get; set; } = 1;

    [field: SerializeField]
    [field: Range(1, 10)]
    public int Damage { get; set; } = 1;

    [field: SerializeField]
    [field: Range(0, 100f)]
    public float Friction { get; set; } = 0;

    [field: SerializeField]
    public bool Bounce { get; set; } = false;

    [field: SerializeField]
    public bool GoThroughHittable { get; set; } = false;

    [field: SerializeField]
    public bool IsRaycast { get; set; } = false;

    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }

    [field: SerializeField]
    public GameObject ImpactEnemyPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 20)]
    public float KnockBackPower { get; set; } = 5f;

    [field: SerializeField]
    [field: Range(0.01f, 1f)]
    public float KnockBackDelay { get; set; } = .1f;
}