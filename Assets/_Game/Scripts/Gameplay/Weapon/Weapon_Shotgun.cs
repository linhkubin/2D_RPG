using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shotgun : WeaponBase
{
    [SerializeField] Transform[] bulletPoints;
    //[SerializeField] BulletBase bulletBase;

    protected override void Shoot()
    {
        for (int i = 0; i < bulletPoints.Length; i++)
        {
            //Instantiate(bulletBase, bulletPoints[i].position, bulletPoints[i].rotation).OnInit(10);
            HBPool.Spawn<BulletBase>(PoolType.BulletBase, bulletPoints[i].position, bulletPoints[i].rotation).OnInit(10);
        }
    }
}
