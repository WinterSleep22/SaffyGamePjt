using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditMenuManager : MonoBehaviour
{
        
    public GameObject endingIllustration;       // 엔딩 일러스트 오브젝트
    public Text congratulationsText;            // 'Congratulations!' 텍스트
    public Text creditText;                     // 크레딧 텍스트
    public Button returnButton;                 // 게임 진입 화면으로 돌아가는 버튼
    public float fadeOutDuration = 5f;          // 페이드 아웃 지속 시간
    public float scrollSpeed = 30f;             // 스크롤 속도
    public float scrollHeight = 1000f;          // 스크롤할 높이

       
    // Start is called before the first frame update
    void Awake()
    {
        //GameObject dontDestroyThese2 = FindObjectOfType<DontDestroyThese2>().gameObject;
        //Destroy(dontDestroyThese2);
    }

    void Start()
    {

        // 버튼을 활성화하고 클릭 이벤트를 설정
        returnButton.gameObject.SetActive(true);
        returnButton.onClick.AddListener(ToMainMenu);

        StartCoroutine(CreditSequence());
    }

    IEnumerator CreditSequence()
    {
        // 엔딩 일러스트를 활성화
        endingIllustration.SetActive(true);

        // 텍스트를 서서히 투명하게 만듦
        StartCoroutine(FadeOutText(congratulationsText));


        // 'Congratulations!' 텍스트를 보여줌
        congratulationsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutDuration); // 5초 동안 대기

        

        // 크레딧 텍스트를 초기 위치로 설정
        creditText.transform.localPosition = new Vector2(creditText.transform.localPosition.x, 0);

        // 크레딧 텍스트를 위로 스크롤
        while (creditText.transform.localPosition.y < scrollHeight)
        {
            creditText.transform.localPosition += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
            yield return null;
        }

        // 스크롤이 완료되면 엔딩 일러스트 비활성화
        endingIllustration.SetActive(false);
    }

    IEnumerator FadeOutText(Text text)
    {
        float startOpacity = text.color.a;
        float rate = 1.0f / fadeOutDuration;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tmpColor = text.color;
            tmpColor.a = Mathf.Lerp(startOpacity, 0, progress);
            text.color = tmpColor;
            progress += rate * Time.deltaTime;
            yield return null;
        }

        text.gameObject.SetActive(false); // 페이드 아웃 후 텍스트 비활성화
    }

    public void ToMainMenu()
    {
        Hub.StageManager.ToScene("Menu");
    }











}
