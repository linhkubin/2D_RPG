using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class BulletBase : GameUnit
{
    public const float TIME_ALIVE = 2f;

    [SerializeField] private TrailRenderer trail;
    [SerializeField] private float moveSpeed = 20;

    float timeAlive;
    protected float damage;
    bool isActive;

    public void OnInit(float damage)
    {
        this.damage = damage;
        this.timeAlive = Time.time + TIME_ALIVE;
        trail.Clear();
        isActive = true;
    }

    public void OnDespawn()
    {
        HBPool.Despawn(this);
    }

    private void Update()
    {
        if (isActive)
        {
            TF.Translate(TF.up * Time.deltaTime * moveSpeed, Space.World);

            if (timeAlive <= Time.time)
            {
                isActive = false;
                OnDespawn();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            Character c = collision.GetComponent<Character>();
            if (c != null)
            {
                c.OnHit(damage);
                isActive = false;
                Invoke(nameof(OnDespawn), 0.5f);
            }
        }
    }
}
