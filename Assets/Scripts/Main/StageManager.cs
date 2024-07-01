using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int currentStage;
    public int[] RequiredKeyAmount;
    public int[] RequiredKeyAmountForTest;
    private Color tmpColor;

    public void Awake()
    {
        tmpColor = Hub.UIManager.transition.GetComponent<Image>().color;
    }


    public void ToMenu()
    {
        StartCoroutine(ToMenuCor());
    }


    IEnumerator ToMenuCor()
    {
        Hub.UIManager.transition.SetActive(true);
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 1f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return new WaitForSeconds(1.7f);
        yield return null;

        SceneManager.LoadScene("0. Menu");
        Hub.GameManager.CurrentGameState = GameState.menu;        


        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 0f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        Hub.UIManager.transition.SetActive(false);
        yield return null;
    }
    
    public void GameOn(string sceneName)
    {
        // ���⼭ �ʱ�ȭ�� �����. 
        Hub.PlayerStatus.isInPortal = false;
        Hub.PlayerStatus.isKeyAll = false;
        Hub.PlayerStatus.KeyCount = 0;
        Hub.PlayerStatus.DestroyFullHP();
        Hub.PlayerStatus.CurrentMP = -100;
        Hub.PlayerStatus.IsFireGet = false;
        Hub.PlayerStatus.IsWaterGet = false;
        Hub.PlayerStatus.IsWindGet = false;
        Hub.PlayerStatus.IsStoneGet = false;
        Hub.PlayerStatus.GetFullHP(3);
        Hub.PlayerStatus.SetCurrentHP(3);
        // ���⿡ ��� ��� �߰��� 
        StartCoroutine(GameOnCor(sceneName));
    }

    IEnumerator GameOnCor(string sceneName)
    {
        Hub.UIManager.transition.SetActive(true);
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 1f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return new WaitForSeconds(1f);
        //���⼭ key list�� �߰���. �ʱ�ȭ�� GameOff()���� ��.
        Hub.PlayerStatus.GetFullKey(RequiredKeyAmount[currentStage]);
        SceneManager.LoadScene(sceneName);
        Hub.GameManager.CurrentGameState = GameState.pause;
        Hub.UIManager.statusUI.SetActive(true);
        Hub.UIManager.dialogUI.SetActive(true);        
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 0f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return null;
        Hub.UIManager.transition.SetActive(false);
    }

    
    
    public void ToScene(string sceneName)
    {   
        Hub.PlayerStatus.isInPortal = false;
        Hub.PlayerStatus.isKeyAll = false;
        Hub.PlayerStatus.KeyCount = 0;        
        StartCoroutine(ToSceneCor(sceneName));        
    }

    IEnumerator ToSceneCor(string sceneName)
    {
        Hub.UIManager.transition.SetActive(true);
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 1f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(sceneName);
        // sceneName ����� ����ϰ� �־ string�� �Ľ��ϱ⺸�ٴ�
        // �ϴ� currentStage�� �Ź� +1 �ϴ� ����� �����. 
        // ������ �� ó���� GameOn()���� �ϰ�, ������ GameOff()���� �ϴϱ�
        // GameOn������ 0�� ä�� �״��, GameOff������ 0���� �ʱ�ȭ�ϴ� ������� ���.
        // ���߿� �ٽ� �����ϱ⳪ �̷� �� �߰��ϰ� �� ��� �̰� �ݵ�� �ٸ� ������� �ٲ����!! 
        Hub.PlayerStatus.DestroyFullKey(RequiredKeyAmount[currentStage]);
        currentStage += 1;
        Hub.PlayerStatus.KeyCount = 0;
        Hub.PlayerStatus.GetFullKey(RequiredKeyAmount[currentStage]);
        

        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 0f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return null;
        Hub.UIManager.transition.SetActive(false);
    }


       
    public void GameOff(string sceneName)
    {
        Hub.PlayerStatus.isInPortal = false;
        Hub.PlayerStatus.isKeyAll = false;
        Hub.PlayerStatus.KeyCount = 0;
        // ���⿡ ��� ��� �߰��� 
        StartCoroutine(GameOffCor(sceneName));
    }

    IEnumerator GameOffCor(string sceneName)
    {
        Hub.UIManager.transition.SetActive(true);
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 1f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return new WaitForSeconds(1.7f);

        SceneManager.LoadScene(sceneName);
        Hub.GameManager.CurrentGameState = GameState.menu;
        // ���⼭ Ű ����Ʈ�� ���ְ� currentStage�� �ʱ�ȭ
        Hub.PlayerStatus.DestroyFullKey(RequiredKeyAmount[currentStage]);
        currentStage = 0;
        Hub.UIManager.dialogUI.SetActive(false);
        Hub.UIManager.statusUI.SetActive(false);
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            tmpColor.a = i;
            Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
            yield return new WaitForSeconds(0.015f);
        }
        tmpColor.a = 0f;
        Hub.UIManager.transition.GetComponent<Image>().color = tmpColor;
        yield return null;
        Hub.UIManager.transition.SetActive(false);
    }









}
