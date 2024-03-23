using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Knife : WeaponBase
{
    [SerializeField] Transform bulletPoint;
    //[SerializeField] BulletBase bulletBase;

    protected override void Shoot()
    {
        //Instantiate(bulletBase, bulletPoint.position, bulletPoint.rotation).OnInit(10);
        HBPool.Spawn<BulletBase>(PoolType.BulletKnife, bulletPoint.position, bulletPoint.rotation).OnInit(10);
    }


}
