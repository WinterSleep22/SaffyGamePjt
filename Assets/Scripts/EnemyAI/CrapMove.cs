using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove; // 행동 지표를 결정할 변수 생성
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        // Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            Trun();
        }
    }

    // 재귀 함수
    // !! 딜레이 없이 재귀함수를 사용하는 것은 아주 위험하다!! ==> 재귀호출을 할 때 시간을 두고 싶다!! ==> Invoke() : 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수

    // 행동 지표를 바꿔줄 함수 하나를 생성
    void Think()
    {
        // Set Next Active

        // Random : 랜덤 수를 생성하는 로직 관련 클래스
        // Range() : 최소 ~ 최대 범위의 랜덤 수 생성 (최대 제외)
        nextMove = Random.Range(-1, 2);

        
        // Sprite Animation
        anim.SetInteger("WalkSpeed", nextMove);

        // Flip Sprite
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;
        
        // Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

    }

    void Trun()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        // CancelInvoke() : 현재 작동 중인 모든 Invoke 함수를 멈추는 함수
        CancelInvoke();
        Invoke("Think", 2);
    }
}
