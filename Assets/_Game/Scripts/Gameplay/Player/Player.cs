using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    [field: SerializeField] public Transform Avatar { get; private set; }
    [field: SerializeField] public Transform DirectTF { get; private set; }
    [field: SerializeField] public SpriteRenderer SpriteRenderer{ get; private set; }

    [SerializeField] private Transform weaponHolder;
    [SerializeField] private WeaponDataSO weaponData;

    [SerializeField] WeaponBase currentWeapon;

    private List<Character> targets = new List<Character>();
    private Character target;
    private bool isControl = true;

    //Test
    int weaponIndex = 0;
    [SerializeField] SkillBase skillDash;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon(WeaponType.Knife);
        skillDash.OnInit(this);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direct = new Vector2 (horizontal, vertical);

        ChangeDirect(direct);
        Move(direct);
        UpdateTarget();

        OnAttack();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon((WeaponType)(++weaponIndex % 4));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            skillDash.OnActive();
        }
    }

    #region Control
    public void ChangeDirect(Vector2 direct)
    {
        if (direct.sqrMagnitude > 0.1f)
        {
            ChangeAnim(Constant.ANIM_RUN);
            if (direct.x != 0) 
            {
                ChangeFacing(direct.x > 0);
            }

            DirectTF.up = direct;
        }
        else
        {
            ChangeAnim(Constant.ANIM_IDLE);
        }
    }

    public void Move(Vector2 direct)
    {
        if (isControl)
        {
            rb.velocity = direct * moveSpeed;
        }
    }

    private void ChangeFacing(bool isRight)
    {
        Avatar.localRotation = isRight ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f);
    }

    internal void Dash(Vector3 direct, float dashSpeed)
    {
        rb.velocity = direct * dashSpeed;
    }

    public void SetControl(bool isControl)
    {
        this.isControl = isControl;
    }

    #endregion

    #region Gun
    public void OnAttack()
    {
        currentWeapon.OnAttack();
    }

    private void UpdateTarget()
    {
        target = GetTargetNearest();
        currentWeapon.SetTarget(target == null ? (DirectTF.up + transform.position) : (target.transform.position));
    }

    public override void AddTarget(Character c)
    {
        targets.Add(c);
    }

    public override void RemoveTarget(Character c)
    {
        targets.Remove(c);
    }


    private Character GetTargetNearest()
    {
        Character c = null;

        if (targets.Count > 0)
        {
            c = targets[0];
            float distance = Vector2.Distance(c.transform.position, transform.position);
            for (int i = 1; i < targets.Count; i++)
            {
                float dis = Vector2.Distance(targets[i].transform.position, transform.position);
                if (dis < distance)
                {
                    distance = dis;
                    c = targets[i];
                }
            }
        }

        return c;
    }

    public void ChangeWeapon(WeaponType weaponType)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        currentWeapon = Instantiate(weaponData.GetWeapon(weaponType), weaponHolder);
    }

    #endregion
}
