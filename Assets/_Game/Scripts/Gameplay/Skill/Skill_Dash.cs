using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Dash : SkillBase
{
    public const float DASH_TIME_STEP = 0.025f;
    public const int DASH_INDEX = -100;

    [SerializeField] float dashSpeed = 25f;
    float time;
    int dashShadowIndex;
    float dashShadowTime;

    protected Sprite Sprite => player.SpriteRenderer.sprite;
    protected Transform PlayerTF => player.Avatar;


    public override void OnActive()
    {
        player.SetControl(false);

        time = TimeActive;
        dashShadowTime = DASH_TIME_STEP;
        dashShadowIndex = DASH_INDEX;
    }

    public override void OnFinish()
    {
        player.SetControl(true);
    }

    private void Update()
    {
        if (time > 0)
        {
            //dash
            time -= Time.deltaTime;
            if (time <= 0) 
            {
                time = 0;
                OnFinish();
            }

            player.Dash(player.DirectTF.up, dashSpeed);

            //dash shadow
            dashShadowTime -= Time.deltaTime;
            if (dashShadowTime <= 0)
            {
                dashShadowTime += DASH_TIME_STEP;
                HBPool.Spawn<DashShadow>(PoolType.DashShadow, PlayerTF.position, PlayerTF.rotation).OnInit(Sprite, dashShadowIndex);
                dashShadowIndex++;
            }
        }
    }
}
