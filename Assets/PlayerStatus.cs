using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    free,
    move,
    gathering
}

public class PlayerStatus : MonoBehaviour
{
    [Header("Status part")]    
    public List<GameObject> fullHP = new List<GameObject>();
    private double _CurrentHP = 0;
    public double CurrentHP
    {
        get { return _CurrentHP;  }
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
            for(int i = 0; i<tmpCount; i++)
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


    [Header("UI part")]
    public GameObject spiritFire;
    public GameObject spiritWater;
    public GameObject spiritWind;
    public GameObject spiritStone;
    public GameObject hpObject;

    [Header("CurrentPosition")]
    public bool isInPortal;

    public void Awake()
    {
        ///SetCurrentHP(3);
    }


    public void Update()
    {
        /*
        if (Hub.InputManager.isGaugeFill == true):
            currentMP += 5;
        */
    }

    


    public void GetFullHP(int amount)
    {
        GameObject thisHP = Instantiate(hpObject);        
        fullHP.Add(thisHP);
        thisHP.transform.SetParent(Hub.UIManager.hpBarObject.transform);
        thisHP.transform.localScale = new Vector3(1, 1, 1);
        //Hub.UIManager.GetFullHP(amount);
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
