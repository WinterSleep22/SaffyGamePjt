using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 몬스터가 공통적으로 가지는 특성 (HP, 이속, 점프력, 플레이어에게 히트 되었는지)
    public int currentHp = 1;
    public float moveSpeed = 5f;
    public float jumpPower = 10;
    public float atkCoolTime = 3f;
    public float atkCoolTimeCalc = 3f;

    public bool isHit = false;
    public bool isGround = true;
    public bool canAtk = true;
    public bool EnemyDirRight;

    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider;
    public GameObject hitBoxCollider;
    public Animator Anim;
    public LayerMask layerMask;


    // Awake : 필요한 컴포넌트 가져오기 + 콜라이더 리셋시키는 코루틴 돌리기
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Anim = GetComponent<Animator>();

        StartCoroutine(CalcCoolTime());
        StartCoroutine(ResetCollider());

    }


    // ResetCollider() 의 기능:
    // 몬스터가 콜라이더에 히트될 때 몬스터의 히트박스 콜라이더가 오프되는데
    // 오프된 히트박스를 다시 켜주는 역할

    // ==> 다단히트를 만들거나 , 이미 겹쳐있는 콜라이더의 트리거를 발동시킬 때 쓸 수 있다.
    IEnumerator ResetCollider()
    {
        while (true)
        {
            yield return null;
            if ( !hitBoxCollider.activeInHierarchy)
            {
                yield return new WaitForSeconds(0.5f);
                hitBoxCollider.SetActive(true);
                isHit = false;
            }
        }
    }
    IEnumerator CalcCoolTime()
    {
        while (true)
        {
            yield return null;
            if (!canAtk)
            {
                atkCoolTimeCalc -= Time.deltaTime;
                if (atkCoolTimeCalc <= 0)
                {
                    atkCoolTimeCalc = atkCoolTime;
                    canAtk = true;
                }
            }
        }
    }

    public bool IsPlayingAnim (string AnimName)
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName(AnimName))
        {
            return true;
        }
        return false;
    }

    public void MyAnimSetTrigger(string AnimName)
    {
        if (!IsPlayingAnim(AnimName))
        {
            Anim.SetTrigger(AnimName);
        }
    }
    
    protected void EnemyFlip()
    {
        EnemyDirRight = !EnemyDirRight;

        Vector3 thisScale = transform.localScale;
        if (EnemyDirRight)
        {
            thisScale.x = -Mathf.Abs(thisScale.x);
        }
        else
        {
            thisScale.x = Mathf.Abs(thisScale.x);
        }
        transform.localScale = thisScale;
        rb.velocity = Vector2.zero;
    }
    protected bool IsPlayerDir()
    {
        if (transform.position.x < PlayerData.Instance.Player.transform.position.x ? EnemyDirRight : !EnemyDirRight)
        {
            return true;
        }
        return false;
    }
    protected void GroundCheck()
    {
        if (Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size, 0, Vector2.down, 0.05f, layerMask))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    public void TakeDamage(int dam)
    {
        currentHp -= dam;
        isHit = true;
        // Knock Back or Dead
        hitBoxCollider.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //if ( collision.transform.CompareTag ( ?? ) )
        //{
        //TakeDamage ( 0 );
        //}
    }





}
