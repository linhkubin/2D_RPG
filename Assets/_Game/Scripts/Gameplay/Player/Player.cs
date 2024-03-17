using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform avatar;

    private string animName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direct = new Vector2 (horizontal, vertical);

        ChangeDirect(direct);
        MoveDirect(direct);
    }

    public void ChangeDirect(Vector2 direct)
    {
        if (direct.sqrMagnitude > 0.1f)
        {
            ChangeAnim(Constant.ANIM_RUN);
            if (direct.x != 0) 
            {
                ChangeFacing(direct.x > 0);
            }
        }
        else
        {
            ChangeAnim(Constant.ANIM_IDLE);
        }
    }

    public void MoveDirect(Vector2 direct)
    {
        rb.velocity = direct * moveSpeed;
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

    private void ChangeFacing(bool isRight)
    {
        avatar.localRotation = isRight ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f);
    }

}
