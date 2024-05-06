using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public string steamURL = "https://store.steampowered.com/";
    public GameObject windowsBackground;
    public GameObject windowCredit;
    public GameObject windowSetting;


    #region ���� ��ư ��Ʈ

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

    #region ���� ��ư ��Ʈ

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
    // ������ʹ� �ش� �޴� ��Ʈ �κ�   //
    //////////////////////////////////////


    #region Credit �޴� ��Ʈ 


    #endregion


    #region Setting �޴� ��Ʈ


    #endregion







}