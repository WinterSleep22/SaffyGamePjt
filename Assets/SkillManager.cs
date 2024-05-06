using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [Header("Amount")]
    public float increseMP;


    public Text tmpTextField;

    public void Awake()
    {
        tmpTextField = Hub.UIManager.tmpTextField;
    }


    public void GatheringEnergy()
    {
        Hub.PlayerStatus.CurrentMP = increseMP;
        tmpTextField.text = "GatheringEngergy";
    }

    public void FireA()
    {
        tmpTextField.text = "FireA!";
    }
    public void FireB()
    {
        tmpTextField.text = "FireB!";
    }
    public void WaterA()
    {
        tmpTextField.text = "WaterA!";
    }
    public void WaterB()
    {
        tmpTextField.text = "WaterB";
    }
    public void WindA()
    {
        tmpTextField.text = "WindA!";
    }
    public void WindB()
    {
        tmpTextField.text = "WindB!";
    }
    public void WindC()
    {
        tmpTextField.text = "WindC!";
    }
}
