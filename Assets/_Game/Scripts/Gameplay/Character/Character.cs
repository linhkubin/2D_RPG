using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float deathTime = 0.5f;

    protected float maxHp;
    protected float hp;
    protected float damage;
    private string animName;

    public Action<Character> OnDeathAction;
    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit(100, 10);
    }

    public virtual void OnInit(float hp, float damage)
    {
        this.maxHp = hp;
        this.hp = hp;
        this.damage = damage;
    }

    public virtual void OnDespawn()
    {

    }

    public virtual void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;
            if (IsDead)
            {
                OnDeath();
            }

            HBPool.Spawn<DamageText>(PoolType.DamageText, transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * 0.5f, Quaternion.identity).OnInit(damage);
        }
    }

    public virtual void OnDeath()
    {
        OnDeathAction?.Invoke(this);
        Invoke(nameof(OnDespawn), deathTime);
    }

    public void ChangeAnim(string animName)
    {
        if (this.animName != animName)
        {
            animator.ResetTrigger(this.animName);
            this.animName = animName;
            animator.SetTrigger(this.animName);
        }
    }

    public virtual void AddTarget(Character c)
    {
    }

    public virtual void RemoveTarget(Character c)
    {
    }

}
