using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PoolControler : MonoBehaviour
{
    [Space]
    [Header("Pool")]
    public List<GameUnit> PoolNoneRoot;

    [Header("Pool")]
    public List<PoolAmount> PoolWithRoot;

    [Header("Particle")]
    public ParticleAmount[] Particle;


    public void Awake()
    {
        for (int i = 0; i < PoolNoneRoot.Count; i++)
        {
            HBPool.Preload(PoolNoneRoot[i], 0, transform);
        }       
        
        for (int i = 0; i < PoolWithRoot.Count; i++)
        {
            HBPool.Preload(PoolWithRoot[i].prefab, PoolWithRoot[i].amount, PoolWithRoot[i].root);
        }

        for (int i = 0; i < Particle.Length; i++)
        {
            ParticlePool.Preload(Particle[i].prefab, Particle[i].amount, Particle[i].root);
            ParticlePool.Shortcut(Particle[i].particleType, Particle[i].prefab);
        }
    }
}

[System.Serializable]
public class PoolAmount
{
    [Header("-- Pool Amount --")]
    public Transform root;
    public GameUnit prefab;
    public int amount;

    public PoolAmount (Transform root, GameUnit prefab, int amount)
    {
        this.root = root;
        this.prefab = prefab;
        this.amount = amount;
    }
}


[System.Serializable]
public class ParticleAmount
{
    public Transform root;
    public ParticleType particleType;
    public ParticleSystem prefab;
    public int amount;
}


public enum ParticleType
{
    BossMinotaur_BoxCrash = 0,
}

public enum PoolType
{
    None = 0,

    PlayerBullet = 1,
    DashShadow = 2,
    Coin = 3,
    HpText = 20,
    PlayerBulletAxe = 21,

    EnemyRino = 40,
    EnemyPlant_1 = 41,
    EnemyPlant_2 = 41,
    EnemyTrunk_1 = 42,
    EnemyMushroom_1 = 43,
    EnemyPig = 44,
    EnemyPigRibbon = 45,

    BulletPlant = 60,
    BulletTrunk = 61,

    BossMinotaur = 70,
    BossMinotaur_BoxCrash = 71,
    BossMinotaur_BulletHell = 72,
}


