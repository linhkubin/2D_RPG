using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    public float TimeCooldown = 1f;
    public float TimeActive = 1f;

    protected Player player;

    public virtual void OnInit(Player player)
    {
        this.player = player;
    }

    public virtual void OnDespawn()
    {

    }

    public abstract void OnActive();
    public abstract void OnFinish();
}
