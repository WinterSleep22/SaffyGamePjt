using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : Enemy
{
    public Transform[] wallCheck;

    private void Awake()
    {
        base.Awake();
        moveSpeed = 0.5f;
        jumpPower = 6f;
    }

    
    void Update()
    {
        if (!isHit) // 플레이어에게 안 맞았다면 바라보는 방향으로 계속 움직이기.
        {
            rb.velocity = new Vector2(-transform.localScale.x * moveSpeed, rb.velocity.y);

            // 벽 체크 오브젝트 0 번은 비어 있고 1번이 Gound면 접프
            if (!Physics2D.OverlapCircle(wallCheck[0].position, 0.1f, layerMask) &&
                Physics2D.OverlapCircle(wallCheck[1].position, 0.1f, layerMask)) 
                // && !Physics2D.Raycast(transform.position, -transform.localScale.x * transform.right, 1f, layerMask)) // 예외 상황을 대비 : 몬스터가 Ground와 너무 가까운 경우 올라가기 빡시기 때문에 적용
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                print("체크");
            }
            else if (Physics2D.OverlapCircle(wallCheck[1].position, 0.1f, layerMask)) // 0, 1 모두 존재하면 flip
            {
                EnemyFlip();
            }
        }

    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.transform.CompareTag("Player"))
        {
            EnemyFlip();
        }
    }
}
