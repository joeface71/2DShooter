using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int playerSortingOrder = 0;
    protected SpriteRenderer weaponRender;

    private void Awake()
    {
        weaponRender = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool val)
    {
        int flipModifier = val ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, flipModifier * Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

    public void RenderBehindHead(bool val)
    {
        if (val)
        {
            weaponRender.sortingOrder = playerSortingOrder - 1;
        }
        else
        {
            weaponRender.sortingOrder = playerSortingOrder + 1;
        }
    }
}
