using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    [HideInInspector]
    public GameObject playerObject;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayer;
    private Vector3 isPositionUpOrDown;

    public float horizontalMove;
    public bool isJumpAvailable = false;

    [Header("Controll Part")]    
    public float jumpForce;
    public float moveSpeed;
    
    

    
    

    private void Awake()
    {
        CatchPlayerObject();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void CatchPlayerObject()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {


        // 점프할때 상승 중인지 하강 중인지 사용할까 말까 하는 부분들
        //animator.SetBool("isOnGround", isOnGround());
        //isPositionUpOrDown = this.transform.position;


        // 왼쪽 오른쪽 
        if (Hub.InputManager.isLeft)
        {
            horizontalMove = Hub.InputManager.horizontalInput * moveSpeed;
        }
        else if (Hub.InputManager.isRight)
        {
            horizontalMove = Hub.InputManager.horizontalInput * moveSpeed;
        }

        // 위 아래
        if (Hub.InputManager.isUP)
        {
            // 전제조건: 포탈 안이 아닐 시
            // 이렇게 전제조건을 계속 사용하거나 추가할 예정
            if (isOnGround() && Hub.PlayerStatus.isInPortal == false)
            {
                isJumpAvailable = true;
                print("jump it");
            }
            else { isJumpAvailable = false; }
        }       


        


    }

    public void FixedUpdate()
    {
        // 이동하기 파트
        // 여기서 CharactorController2D에 값을 줌. 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumpAvailable);
        isJumpAvailable = false;


        // 에너지 모으기
        if (Hub.InputManager.isDown && Hub.InputManager.isA)
        {
            Hub.SkillManager.GatheringEnergy();
        }


    }

    public bool isOnGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
