using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : GameUnit
{
    public const float TIME_ALIVE = 1;
    [SerializeField] TextMeshProUGUI damageText;

    public void OnInit(float damage)
    {
        damageText.text = damage.ToString("F0");
        OnDespawn(TIME_ALIVE);
    }
}
