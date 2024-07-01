using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Status")]
    public Slider mpSlider;
    public Text tmpTextField;
    public GameObject hpBarObject;
    public GameObject keyBarObject;
    public GameObject keyObject;
    public Sprite keyObject_not_found;
    public Sprite keyObject_found;
    
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

    [Header("UI")]
    public GameObject statusUI;
    public GameObject dialogUI;
    public int currentDialog;
    //dialog는 a_Dialog.cs에 있음.
    public GameObject transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
