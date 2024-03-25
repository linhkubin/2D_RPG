using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadow : GameUnit
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public void OnInit(Sprite sprite, int index)
    {
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = index;
        OnDespawn(0.3f);
    }
}
