using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider mpSlider;
    public Text tmpTextField;
    public GameObject hpBarObject;

    [Header("Spirits")]
    public GameObject spiritFireMainUI;
    public GameObject spiritFireCoolDown;
    public GameObject spiritFireCover;
    [Space]
    public GameObject spiritWaterMainUI;
    public GameObject spiritWaterCoolDown;
    public GameObject spiritWaterCover;
    [Space]
    public GameObject spiritWindMainUI;
    public GameObject spiritWindCoolDown;
    public GameObject spiritWindCover;
    [Space]
    public GameObject spiritStoneMainUI;
    public GameObject spiritStoneCoolDown;
    public GameObject spiritStoneCover;


    // Start is called before the first frame update
    void Start()
    {
        
    }
}
