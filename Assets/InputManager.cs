using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Key Configure")]
    public string keyA = "z";
    public string keyB = "x";
    public string keyC = "c";

    public bool isUP = false;
    public bool isDown = false;
    public bool isLeft = false;
    public bool isRight = false;
    public float horizontalInput;
    public float verticalInput;

    public bool isA = false;
    public bool isB = false;
    public bool isC = false;

    public bool isAOnce = false;
    public bool isBOnce = false;
    public bool isCOnce = false;

    public bool isESC = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        
        isA = false;
        isB = false;
        isC = false;
        isESC = false;

        // ���� ������
        if (horizontalInput > 0f)
        {
            Debug.Log("���������� �̵� ��");
            isLeft = false;
            isRight = true;
        }
        else if (horizontalInput < 0f)
        {
            Debug.Log("�������� �̵� ��");
            isLeft = true;
            isRight = false;
        }
        else { isLeft = false; isRight = false; }

        // �� �Ʒ�
        if (verticalInput > 0f)
        {
            Debug.Log("���� �̵� ��");
            isDown = false;
            isUP = true;

        }
        else if (verticalInput < 0f)
        {
            Debug.Log("�Ʒ��� ���̱�");
            isUP = false;
            isDown = true;
            
        }
        else {
            isUP = false;
            isDown = false;
        }



        if (Input.GetKey(keyA))
        {
            isA = true;
            if (Input.GetKeyDown(keyA)) isAOnce = true;
        }
        if (Input.GetKey(keyB))
        {
            isA = true;
            if (Input.GetKeyDown(keyB)) isAOnce = true;
        }
        if (Input.GetKey(keyC))
        {
            isA = true;
            if (Input.GetKeyDown(keyC)) isAOnce = true;
        }
        //else isA = false;



    }
}
