using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField] private int maxHealth;
    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            UIHealth.UpdateUI(health);
        }
    }

    private bool dead = false;

    [SerializeField] private PlayerWeapon playerWeapon;

    [field: SerializeField]
    public UIHealth UIHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake()
    {
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }

    private void Start()
    {
        Health = maxHealth;
        UIHealth.Initialize(Health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead == false)
        {
            Health--;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = other.gameObject.GetComponent<Resource>();
            if (resource != null)
            {
                switch (resource.ResourceData.ResourceType)
                {
                    case ResourceTypeEnum.Health:
                        if (Health >= maxHealth)
                        {
                            return;
                        }
                        Health += resource.ResourceData.GetAmount();
                        resource.PickUpResource();
                        break;
                    case ResourceTypeEnum.Ammo:
                        if (playerWeapon.AmmoFull)
                        {
                            return;
                        }
                        playerWeapon.AddAmmo(resource.ResourceData.GetAmount());
                        resource.PickUpResource();
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
