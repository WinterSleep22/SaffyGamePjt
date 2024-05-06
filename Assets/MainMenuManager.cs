using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public string steamURL = "https://store.steampowered.com/";
    public GameObject windowsBackground;
    public GameObject windowCredit;
    public GameObject windowSetting;


    #region 메인 버튼 파트

    void Awake()
    {

    }

    public void ButtonGameStart()
    {
        Hub.StageManager.ToScene("Stage1");
    }

    public void ButtonCredit()
    {
        windowsBackground.SetActive(true);
        windowCredit.SetActive(true);
        //Hub.SoundManager.sfxButton();
    }

    public void ButtonExit()
    {
        Application.Quit(); 
    }

    #endregion

    #region 서브 버튼 파트

    public void ButtonSetting()
    {
        windowsBackground.SetActive(true);
        windowSetting.SetActive(true);
    }

    public void ButtonSteam()
    {
        Application.OpenURL(steamURL);
    }

    #endregion


    //////////////////////////////////////
    // 여기부터는 해당 메뉴 파트 부분   //
    //////////////////////////////////////


    #region Credit 메뉴 파트 


    #endregion


    #region Setting 메뉴 파트


    #endregion







}