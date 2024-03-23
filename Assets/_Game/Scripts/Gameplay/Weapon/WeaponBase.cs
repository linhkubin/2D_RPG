using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] Transform tf;
    [SerializeField] Transform gunChild;
    [SerializeField] float reloadTime = 1f;
    protected Player player;
    protected float damage;
    protected float time;

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time < 0 ) 
            {
                time = 0;
            }

            //TODO: update UI 
        }
    }

    public void OnInit(Player player, float damage)
    {
        this.player = player;
        this.damage = damage;

        time = 0;
    }

    public void OnAttack()
    {
        if (time <= 0)
        {
            Shoot();
            time = reloadTime;
        }
    }

    protected abstract void Shoot();

    public void SetTarget(Vector3 target)
    {
        tf.up = target - tf.position;
        gunChild.localRotation = Quaternion.Euler(0, tf.up.x >= 0 ? 0 : 180, 0);
    }

}
