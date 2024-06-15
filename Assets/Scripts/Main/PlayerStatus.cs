using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    free,
    move,
    gathering,
    skill
}

public enum Direct
{
    left,
    right
}

public class PlayerStatus : MonoBehaviour
{
    [Header("SkillCost part")]
    public float fire1Amount;
    public float fire2Amount;
    public float water1Amount;
    public float wind1Amount;

    [Header("Status part")]
    public List<GameObject> fullHP = new List<GameObject>();
    private double _CurrentHP = 0;
    public double CurrentHP
    {
        get { return _CurrentHP; }
        set
        {
            // ü���� �������� ���� ���ظ� �Դ� ���� Ȯ�� 
            if (_CurrentHP > value)
            {
                //Ÿ�� ����Ʈ 
                //Ÿ�� ����
                foreach (GameObject heart in fullHP)
                {
                    heart.GetComponent<a_HPIcon>().half1.SetActive(false);
                    heart.GetComponent<a_HPIcon>().half2.SetActive(false);
                }
            }
            else //ü�� ȸ�� ���� 


            // �ʰ����� �ʵ��� ����
            if (value > fullHP.Count) value = fullHP.Count;
            _CurrentHP = value;

            // �������� ����
            int tmpCount = (int)value;
            double tmpExtra = value - (double)tmpCount;
            for (int i = 0; i < tmpCount; i++)
            {
                fullHP[i].GetComponent<a_HPIcon>().half1.SetActive(true);
                fullHP[i].GetComponent<a_HPIcon>().half2.SetActive(true);
            }
            if (tmpExtra > 0)
            {
                fullHP[tmpCount].GetComponent<a_HPIcon>().half1.SetActive(true);
            }

            if (_CurrentHP <= 0)
            {
                // ���� �� ó�� 
            }
        }
    }
    [Range(0, 100)]
    private float _CurrentMP = 0;
    public float CurrentMP
    {
        get { return _CurrentMP; }
        set
        {
            if (_CurrentMP > 100) _CurrentMP = 100;
            else if (_CurrentMP < 0) _CurrentMP = 0;
            else _CurrentMP += value;

            Debug.Log(_CurrentMP);
            Hub.UIManager.mpSlider.value = _CurrentMP / 100;
        }
    }

    public bool isFireGet;
    public bool isWaterGet;
    public bool isWindGet;
    public bool isStoneGet;
    public PlayerState currentPlayerState;
    //�������� ���������� Ȯ��
    public Direct currentDirection;


    [Header("UI part")]
    public GameObject spiritFire;
    public GameObject spiritWater;
    public GameObject spiritWind;
    public GameObject spiritStone;
    public GameObject hpObject;

    [Header("CurrentPosition")]
    public bool isInPortal;
    public bool isKey;
    private int _KeyCount = 0;
    public int KeyCount
    {
        get { return _KeyCount; }
        set
        {
            _KeyCount = value;
        }

    }



    // �߰� 
    public bool isGetHeart;
    public float effectDuration = 4f;
    public GameObject heartEffectPrefab;





    public void Awake()
    {
        GetFullHP(3);
        SetCurrentHP(3);
        currentPlayerState = PlayerState.free;
    }


    public void Update()
    {
        /*
        if (Hub.InputManager.isGaugeFill == true):
            currentMP += 5;
        */
        //�����̰� �߰��� ��
        if (isGetHeart == true)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(ShowHeartEffect(playerObject.transform));
            isGetHeart = false;
        }
    }

    //�����̰� �߰��� �� 
    IEnumerator ShowHeartEffect(Transform playerTransform)
    {
        // ��Ʈ ����Ʈ�� �÷��̾� ��ġ�� ����
        Debug.Log("Heart effect coroutine started");
        GameObject heartEffectInstance = Instantiate(heartEffectPrefab, playerTransform.position + new Vector3(0, 3, 0), Quaternion.identity);
        heartEffectInstance.transform.SetParent(playerTransform); // ����Ʈ�� �÷��̾��� �ڽ����� �����Ͽ� �Բ� �����̵��� ��

        // ������ �ð���ŭ ���
        float rotationSpeed = 180f; // �ʴ� ȸ�� �ӵ� (��)
        float elapsedTime = 0f; // ��� �ð�

        // ������ �ð���ŭ ����ϸ鼭 ȸ��
        while (elapsedTime < effectDuration)
        {
            heartEffectInstance.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // z�� �������� ȸ��
            elapsedTime += Time.deltaTime;
            yield return null; // ���� �����ӱ��� ���
        }
        // yield return new Wait    ForSeconds(effectDuration);

        // �ð��� ������ ����Ʈ ����
        Debug.Log("Destroying heart effect");
        Destroy(heartEffectInstance);
    }










    public void GetFullHP(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject thisHP = Instantiate(hpObject);
            fullHP.Add(thisHP);
            thisHP.transform.SetParent(Hub.UIManager.hpBarObject.transform);
            thisHP.transform.localScale = new Vector3(1, 1, 1);
            //Hub.UIManager.GetFullHP(amount);
        }

    }

    public void SetCurrentHP(double amount)
    {
        double tmp = CurrentHP + amount;
        Debug.Log(tmp);
        CurrentHP = tmp;


    }

    public void SetCoolTime(int sprNum, float coolTime)
    {
        switch (sprNum)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }







    /* ������ �ٳన 
    
    




    */







}
