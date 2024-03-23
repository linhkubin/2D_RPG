using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MachineGun : WeaponBase
{
    [SerializeField] int bulletAmount = 5;
    [SerializeField] float stepTime = 0.1f;
    [SerializeField] Transform[] bulletPoints;
    //[SerializeField] BulletBase bulletBase;

    protected override void Shoot()
    {
        StartCoroutine(IEShoot());
    }

    private IEnumerator IEShoot()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            int index = Random.Range(0, bulletPoints.Length);
            //Instantiate(bulletBase, bulletPoints[index].position, bulletPoints[index].rotation).OnInit(10);
            HBPool.Spawn<BulletBase>(PoolType.BulletBase, bulletPoints[index].position, bulletPoints[index].rotation).OnInit(10);
            yield return new WaitForSeconds(stepTime);
        }
    }
}
