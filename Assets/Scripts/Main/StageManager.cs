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
        // 여기서 초기화를 담당함. 
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
        // 여기에 허브 기능 추가함 
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
        //여기서 key list를 추가함. 초기화는 GameOff()에서 함.
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
        // sceneName 방식을 사용하고 있어서 string을 파싱하기보다는
        // 일단 currentStage를 매번 +1 하는 방식을 사용함. 
        // 어차피 맨 처음은 GameOn()에서 하고, 엔딩은 GameOff()에서 하니까
        // GameOn에서는 0인 채로 그대로, GameOff에서는 0으로 초기화하는 방식으로 사용.
        // 나중에 다시 시작하기나 이런 걸 추가하게 될 경우 이걸 반드시 다른 방식으로 바꿔야함!! 
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
        // 여기에 허브 기능 추가함 
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
        // 여기서 키 리스트를 없애고 currentStage를 초기화
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
