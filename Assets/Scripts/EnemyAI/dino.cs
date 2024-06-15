using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : Enemy
{
    // 원거리 몬스터는 idle, run, attack 3가지 상태를 가지고 있다
    public enum State
    {
        Idle,
        Run,
        Attack
    };

    public State currentState = State.Idle;

    // 원거리 공격이 생성될 위치와 총알프리펨 선언하기
    public Transform[] wallCheck;
    public Transform genPoint;
    public GameObject Bullet;

    WaitForSeconds Delay1000 = new WaitForSeconds(1f);

    // Awake에서 이 몬스터의 스탯을 정하기
    void Awake()
    {
        base.Awake();
        moveSpeed = 1f;
        jumpPower = 15f;
        currentHp = 4;
        atkCoolTime = 3f;
        atkCoolTimeCalc = atkCoolTime;

        StartCoroutine(FSM());
    }

    // 코루틴으로 FSM을 돌리기
    IEnumerator FSM ()
    {
        while (true) 
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    // Idle 상태 : 50% 확률로 Flip을 하고 1초 후 Run 상태로 변경하기
    IEnumerator Idle ()
    {
        yield return null;
        MyAnimSetTrigger("Idle");

        if (Random.value > 0.5f)
        {
            EnemyFlip();
        }
        yield return Delay1000;
        currentState = State.Run;
    }
    IEnumerator Run()
    {
        yield return null;
        float runTime = Random.Range(2f, 3f);
        while (runTime >= 0f)
        {
            runTime -= Time.deltaTime;
            MyAnimSetTrigger("Run");
            if (!isHit)
            {
                rb.velocity = new Vector2(-transform.localScale.x * moveSpeed, rb.velocity.y);

                if (Physics2D.OverlapCircle(wallCheck[1].position, 0.01f, layerMask))
                {
                    EnemyFlip();
                }
                if (canAtk && IsPlayerDir())
                {
                    if (Vector2.Distance(transform.position, PlayerData.Instance.Player.transform.position) < 15f)
                    {
                        currentState = State.Attack;
                        break;
                    }
                }
            }
            yield return null;
        }
        if (currentState != State.Attack)
        {
            if (Random.value > 0.5f)
            {
                EnemyFlip();
            }
            else
            {
                currentState = State.Idle;
            }
        }
        IEnumerator Attack()
        {
            yield return null;

            canAtk = false;
            rb.velocity = new Vector2(0, jumpPower);
            MyAnimSetTrigger("Attack");

            yield return Delay1000;
            currentState = State.Idle;
        }

        void Fire()
        {
            GameObject bulletClone = Instantiate(Bullet, genPoint.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * -transform.localScale.x * 10f;
            bulletClone.transform.localScale = new Vector2(transform.localScale.x, 1f);

        }
    }




}
