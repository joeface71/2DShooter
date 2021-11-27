using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject muzzle;

    [SerializeField]
    protected int ammo = 10;

    [SerializeField] protected WeaponDataSO weaponData;

    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);
        }
    }

    public bool AmmoFull { get => Ammo >= weaponData.AmmoCapacity; }

    protected bool isShooting = false;

    [SerializeField] protected bool reloadCoroutine = false;

    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }

    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; }

    private void Start()
    {
        Ammo = weaponData.AmmoCapacity;
    }


    public void TryShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void Reload(int ammo)
    {
        Ammo += ammo;
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && reloadCoroutine == false)
        {
            if (Ammo > 0)
            {
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishShooting();
        }
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNexShotCoroutine());
        if (weaponData.AutomaticFire == false)
        {
            isShooting = false;
        }
    }

    protected IEnumerator DelayNexShotCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngel(muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bullePrefab = Instantiate(weaponData.BulletData.bulletPrefab, position, rotation);
        bullePrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }

    private Quaternion CalculateAngel(GameObject muzzle)
    {
        float spread = UnityEngine.Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
}