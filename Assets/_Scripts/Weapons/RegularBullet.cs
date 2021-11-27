using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidbody2d;
    private bool isDead = false;

    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2d = GetComponent<Rigidbody2D>();
            rigidbody2d.drag = bulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody2d != null && BulletData != null)
        {
            rigidbody2d.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Added to elimate multiple kills
        if (isDead)
            return;
        isDead = true;
        // end edit
        var hittable = other.GetComponent<IHittable>();
        hittable?.GetHit(bulletData.Damage, gameObject);

        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(other);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(other);
        }
        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D collider)
    {
        var knockBack = collider.GetComponent<IKnockBack>();
        knockBack?.KnockBack(transform.right, BulletData.KnockBackPower, BulletData.KnockBackDelay);
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Instantiate(BulletData.ImpactEnemyPrefab, collider.transform.position + (Vector3)randomOffset, Quaternion.identity);
    }

    private void HitObstacle(Collider2D collider)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider != null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }
}