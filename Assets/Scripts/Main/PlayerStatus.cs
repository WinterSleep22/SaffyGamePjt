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
            // 체력이 더해지는 건지 피해를 입는 건지 확인 
            if (_CurrentHP > value)
            {
                //타격 이펙트 
                //타격 사운드
                foreach (GameObject heart in fullHP)
                {
                    heart.GetComponent<a_HPIcon>().half1.SetActive(false);
                    heart.GetComponent<a_HPIcon>().half2.SetActive(false);
                }
            }
            else //체력 회복 사운드 


            // 초과되지 않도록 보정
            if (value > fullHP.Count) value = fullHP.Count;
            _CurrentHP = value;

            // 실제적인 보정
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
                // 게임 셋 처리 
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
    //왼쪽인지 오른쪽인지 확인
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



    // 추가 
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
        //현성이가 추가한 거
        if (isGetHeart == true)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(ShowHeartEffect(playerObject.transform));
            isGetHeart = false;
        }
    }

    //현성이가 추가한 거 
    IEnumerator ShowHeartEffect(Transform playerTransform)
    {
        // 하트 이펙트를 플레이어 위치에 생성
        Debug.Log("Heart effect coroutine started");
        GameObject heartEffectInstance = Instantiate(heartEffectPrefab, playerTransform.position + new Vector3(0, 3, 0), Quaternion.identity);
        heartEffectInstance.transform.SetParent(playerTransform); // 이펙트를 플레이어의 자식으로 설정하여 함께 움직이도록 함

        // 설정된 시간만큼 대기
        float rotationSpeed = 180f; // 초당 회전 속도 (도)
        float elapsedTime = 0f; // 경과 시간

        // 설정된 시간만큼 대기하면서 회전
        while (elapsedTime < effectDuration)
        {
            heartEffectInstance.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // z축 방향으로 회전
            elapsedTime += Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }
        // yield return new Wait    ForSeconds(effectDuration);

        // 시간이 지나면 이펙트 제거
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







    /* 최현성 다녀감 
    
    




    */







}
