using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    [HideInInspector]
    public GameObject playerObject;
    public GameObject playerUI;
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
        playerUI = FindObjectOfType<a_PlayerUI>().gameObject;
    }

    public void Update()
    {


        // �����Ҷ� ��� ������ �ϰ� ������ ����ұ� ���� �ϴ� �κе�
        //animator.SetBool("isOnGround", isOnGround());
        //isPositionUpOrDown = this.transform.position;


        // ���� ������ 
        if (Hub.PlayerStatus.currentPlayerState == PlayerState.free |
            Hub.PlayerStatus.currentPlayerState == PlayerState.move)
        {
            if (Hub.InputManager.isLeft)
            {
                horizontalMove = Hub.InputManager.horizontalInput * moveSpeed;
                Hub.PlayerStatus.currentDirection = Direct.left;
            }
            else if (Hub.InputManager.isRight)
            {
                horizontalMove = Hub.InputManager.horizontalInput * moveSpeed;
                Hub.PlayerStatus.currentDirection = Direct.right;
            }
        }

        // ���� ������ ��� ���� ������ horizontalMove�� 0����
        if (Hub.InputManager.isLeft == false &&
            Hub.InputManager.isRight == false)
        {
            //�ε巴�� �ٿ��� �� �� ���� ������ �ϴ��� �׳� �ٷ� 0���� 
            horizontalMove = 0f;
        }



        // �� �Ʒ�
        if (Hub.InputManager.isB &&
            (Hub.PlayerStatus.currentPlayerState == PlayerState.free |
            Hub.PlayerStatus.currentPlayerState == PlayerState.move))
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

        /*
        if (Hub.PlayerStatus.currentPlayerState == PlayerState.free)
        {
            print("hey");
        }*/

        //��ų UI ���ų� ����
        if (Hub.PlayerStatus.currentPlayerState == PlayerState.free && 
            Hub.InputManager.isC == true &&
            playerUI.GetComponent<a_PlayerUI>().isOccupied == false)
        {
            Hub.PlayerStatus.currentPlayerState = PlayerState.skill;
            playerUI.GetComponent<a_PlayerUI>().isOccupied = true;
            playerUI.GetComponent<a_PlayerUI>().SkillListOn();
        }

        if (Hub.PlayerStatus.currentPlayerState == PlayerState.skill &&
            Hub.InputManager.isC == true &&
            playerUI.GetComponent<a_PlayerUI>().isOccupied == false)
        {
            Hub.PlayerStatus.currentPlayerState = PlayerState.free;
            playerUI.GetComponent<a_PlayerUI>().isOccupied = true;
            playerUI.GetComponent<a_PlayerUI>().SkillListOff();
        }



    }

    public void FixedUpdate()
    {
        // �̵��ϱ� ��Ʈ
        // ���⼭ CharactorController2D�� ���� ��. 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumpAvailable);
        isJumpAvailable = false;


        // ������ ������
        if (Hub.InputManager.isDown &&
            Hub.InputManager.isA &&
            (Hub.PlayerStatus.currentPlayerState == PlayerState.free |
            Hub.PlayerStatus.currentPlayerState == PlayerState.move |
            Hub.PlayerStatus.currentPlayerState == PlayerState.gathering))
        {
            Hub.PlayerStatus.currentPlayerState = PlayerState.gathering;
            Hub.SkillManager.GatheringEnergy();
        }
        else if (Hub.PlayerStatus.currentPlayerState == PlayerState.gathering) Hub.PlayerStatus.currentPlayerState = PlayerState.free; 


    }

    public bool isOnGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.5f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
