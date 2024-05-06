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


        // �����Ҷ� ��� ������ �ϰ� ������ ����ұ� ���� �ϴ� �κе�
        //animator.SetBool("isOnGround", isOnGround());
        //isPositionUpOrDown = this.transform.position;


        // ���� ������ 
        if (Hub.InputManager.isLeft)
        {
            horizontalMove = Hub.InputManager.horizontalInput * moveSpeed;
        }
        else if (Hub.InputManager.isRight)
        {
            horizontalMove = Hub.InputManager.horizontalInput * moveSpeed;
        }

        // �� �Ʒ�
        if (Hub.InputManager.isUP)
        {
            // ��������: ��Ż ���� �ƴ� ��
            // �̷��� ���������� ��� ����ϰų� �߰��� ����
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
        // �̵��ϱ� ��Ʈ
        // ���⼭ CharactorController2D�� ���� ��. 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumpAvailable);
        isJumpAvailable = false;


        // ������ ������
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
