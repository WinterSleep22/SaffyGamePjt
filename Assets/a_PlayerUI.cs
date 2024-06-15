using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class a_PlayerUI : MonoBehaviour
{
    public GameObject playerLocation;
    [Header("Skill Part")]
    public GameObject skillBackground;
    public GameObject skillList;
    
    public GameObject topPos;
    public GameObject bottomPos;
    public GameObject leftPos;
    public GameObject rightPos;
    private string currentPos;

    public GameObject closeTop;
    public GameObject closeBottom;
    public GameObject closeLeft;
    public GameObject closeRight;


    public GameObject interactionIndication;


    public bool isOccupied = false;
    // ��ųUI�� �����ų� 70%�� ���ĸ� �ִ� ��
    private Color tmpColor;


    // Start is called before the first frame update
    void Start()
    {
        tmpColor = closeTop.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerLocation.transform.position;

        //��ų ���� �����̱� 
        if (Hub.PlayerStatus.currentPlayerState == PlayerState.skill)
        {
            
            if (Hub.PlayerStatus.isFireGet &&
                Hub.InputManager.isUP)
            {
                topPos.SetActive(false);
                bottomPos.SetActive(false);
                leftPos.SetActive(false);
                rightPos.SetActive(false);
                topPos.SetActive(true);
                currentPos = "UP";
            }
            if (Hub.PlayerStatus.isWindGet &&
                Hub.InputManager.isDown)
            {
                topPos.SetActive(false);
                bottomPos.SetActive(false);
                leftPos.SetActive(false);
                rightPos.SetActive(false);
                bottomPos.SetActive(true);
                currentPos = "DOWN";
            }
            if (Hub.PlayerStatus.isWaterGet &&
                Hub.InputManager.isLeft)
            {
                topPos.SetActive(false);
                bottomPos.SetActive(false);
                leftPos.SetActive(false);
                rightPos.SetActive(false);
                leftPos.SetActive(true);
                currentPos = "LEFT";
            }
            if (Hub.PlayerStatus.isFireGet &&
                Hub.InputManager.isRight)
            {
                topPos.SetActive(false);
                bottomPos.SetActive(false);
                leftPos.SetActive(false);
                rightPos.SetActive(false);
                rightPos.SetActive(true);
                currentPos = "RIGHT";
            }
        }

        //��ų ��� �κ�
        if (Hub.PlayerStatus.currentPlayerState == PlayerState.skill)
        {
            if (Hub.InputManager.isAOnce)
            {
                if (currentPos == "UP" &&
                    Hub.PlayerStatus.CurrentMP >= Hub.PlayerStatus.fire1Amount)
                {
                    SkillListCancel();
                    Hub.PlayerStatus.CurrentMP = - Hub.PlayerStatus.fire1Amount;
                    Hub.SkillManager.FireA();
                }

                if (currentPos == "RIGHT" &&
                    Hub.PlayerStatus.CurrentMP >= Hub.PlayerStatus.fire2Amount)
                {
                    SkillListCancel();
                    Hub.PlayerStatus.CurrentMP = - Hub.PlayerStatus.fire2Amount;
                    Hub.SkillManager.FireB();
                }

                if (currentPos == "LEFT" &&
                    Hub.PlayerStatus.CurrentMP >= Hub.PlayerStatus.water1Amount)
                {
                    SkillListCancel();
                    Hub.PlayerStatus.CurrentMP = - Hub.PlayerStatus.water1Amount;
                    Hub.SkillManager.WaterA();
                }

                if (currentPos == "DOWN" &&
                    Hub.PlayerStatus.CurrentMP >= Hub.PlayerStatus.wind1Amount)
                {
                    SkillListCancel();
                    Hub.PlayerStatus.CurrentMP = - Hub.PlayerStatus.wind1Amount;
                    Hub.SkillManager.WindA();
                }
            }


        }

    }

    // ���⼭ �ǽð����� ������ ���� �ش� ��ų ��� �����ϴٰ� ǥ����. 
    private void FixedUpdate()
    {
        if (Hub.PlayerStatus.currentPlayerState == PlayerState.skill)
        {
            if (Hub.PlayerStatus.isFireGet)
            {
                if (Hub.PlayerStatus.CurrentMP < Hub.PlayerStatus.fire1Amount)
                {
                    tmpColor.a = 0.7f;
                    closeTop.GetComponent<Image>().color = tmpColor;
                }
                else
                {
                    tmpColor.a = 0f;
                    closeTop.GetComponent<Image>().color = tmpColor;
                }
            }
            if (Hub.PlayerStatus.isFireGet)
            {
                if (Hub.PlayerStatus.CurrentMP < Hub.PlayerStatus.fire2Amount)
                {
                    tmpColor.a = 0.7f;
                    closeRight.GetComponent<Image>().color = tmpColor;
                }
                else
                {
                    tmpColor.a = 0f;
                    closeRight.GetComponent<Image>().color = tmpColor;
                }
            }
            if (Hub.PlayerStatus.isWaterGet)
            {
                if (Hub.PlayerStatus.CurrentMP < Hub.PlayerStatus.water1Amount)
                {
                    tmpColor.a = 0.7f;
                    closeLeft.GetComponent<Image>().color = tmpColor;
                }
                else
                {
                    tmpColor.a = 0f;
                    closeLeft.GetComponent<Image>().color = tmpColor;
                }
            }
            if (Hub.PlayerStatus.isWindGet)
            {
                if (Hub.PlayerStatus.CurrentMP < Hub.PlayerStatus.wind1Amount)
                {
                    tmpColor.a = 0.7f;
                    closeBottom.GetComponent<Image>().color = tmpColor;
                }
                else
                {
                    tmpColor.a = 0f;
                    closeBottom.GetComponent<Image>().color = tmpColor;
                }
            }

        }
        
    }


    #region ��ų����Ʈ ���ų� ����


    public void SkillListOn()
    {
        //� ��ų�� Ŀ���� ���� ������ ����, Ŀ���� �ѵ� ���ķ� ����
        tmpColor.a = 0f;
        closeTop.GetComponent<Image>().color = tmpColor;
        closeRight.GetComponent<Image>().color = tmpColor;
        closeLeft.GetComponent<Image>().color = tmpColor;
        closeBottom.GetComponent<Image>().color = tmpColor;
        tmpColor.a = 1f;
        if (Hub.PlayerStatus.isFireGet == false) closeTop.GetComponent<Image>().color = tmpColor;
        if (Hub.PlayerStatus.isFireGet == false) closeRight.GetComponent<Image>().color = tmpColor;
        if (Hub.PlayerStatus.isWaterGet == false) closeLeft.GetComponent<Image>().color = tmpColor;
        if (Hub.PlayerStatus.isWindGet == false) closeBottom.GetComponent<Image>().color = tmpColor;

        topPos.SetActive(false);
        bottomPos.SetActive(false);
        leftPos.SetActive(false);
        rightPos.SetActive(false);
        skillBackground.SetActive(true);
        skillList.SetActive(true);
        if (Hub.PlayerStatus.isFireGet == true)
        {
            topPos.SetActive(true);
            currentPos = "UP";
        }
        skillList.transform.localScale = new Vector2(0.01f, 0.01f);
        StartCoroutine(SkillListOn2());

    }

    IEnumerator SkillListOn2()
    {
        while (skillList.transform.localScale.x < 1)
        {
            //�̰� 0.035 �ƴϸ� 0.05�� �����ϸ� ���� �� 
            skillList.transform.localScale = new Vector2(skillList.transform.localScale.x + 0.05f, skillList.transform.localScale.y + 0.05f);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        isOccupied = false;
        yield return null;
    }


    //�ٽ� ��ų ����Ʈ�� �������� �� 
    public void SkillListOff()
    {
        skillBackground.SetActive(false);
        StartCoroutine(SkillListOff2());
    }

    IEnumerator SkillListOff2()
    {
        while (skillList.transform.localScale.x > 0.01f)
        {
            skillList.transform.localScale = new Vector2(skillList.transform.localScale.x - 0.07f, skillList.transform.localScale.y - 0.07f);
            yield return null;
        }
        skillList.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        Hub.PlayerStatus.currentPlayerState = PlayerState.free;
        isOccupied = false;

        yield return null;
    }



    //�ǰݴ��ϰų�, ��ų ����ؼ� �� ���� ��������
    public void SkillListCancel()
    {
        skillBackground.SetActive(false);
        skillList.SetActive(false);        
        Hub.PlayerStatus.currentPlayerState = PlayerState.free;
    }


    #endregion




}
