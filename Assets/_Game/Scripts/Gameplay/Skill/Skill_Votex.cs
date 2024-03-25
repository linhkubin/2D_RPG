using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Votex : SkillBase
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] Transform tf;
    [SerializeField] GameObject child;
    [SerializeField] float rotateSpeed = 500;
    float time;

    public override void OnActive()
    {
        time = 0;
        tf.localScale = Vector3.one * curve.Evaluate(0);
        child.SetActive(true);
    }

    public override void OnFinish()
    {
        child.SetActive(false);
    }

    private void Update()
    {
        time += Time.deltaTime;
        tf.localScale = Vector3.one * curve.Evaluate(time);
        tf.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();
        if (c != null)
        {
            c.OnHit(player.Damage);
        }
    }
}
