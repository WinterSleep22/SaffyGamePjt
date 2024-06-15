using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditMenuManager : MonoBehaviour
{
        
    public GameObject endingIllustration;       // ���� �Ϸ���Ʈ ������Ʈ
    public Text congratulationsText;            // 'Congratulations!' �ؽ�Ʈ
    public Text creditText;                     // ũ���� �ؽ�Ʈ
    public Button returnButton;                 // ���� ���� ȭ������ ���ư��� ��ư
    public float fadeOutDuration = 5f;          // ���̵� �ƿ� ���� �ð�
    public float scrollSpeed = 30f;             // ��ũ�� �ӵ�
    public float scrollHeight = 1000f;          // ��ũ���� ����

       
    // Start is called before the first frame update
    void Awake()
    {
        //GameObject dontDestroyThese2 = FindObjectOfType<DontDestroyThese2>().gameObject;
        //Destroy(dontDestroyThese2);
    }

    void Start()
    {

        // ��ư�� Ȱ��ȭ�ϰ� Ŭ�� �̺�Ʈ�� ����
        returnButton.gameObject.SetActive(true);
        returnButton.onClick.AddListener(ToMainMenu);

        StartCoroutine(CreditSequence());
    }

    IEnumerator CreditSequence()
    {
        // ���� �Ϸ���Ʈ�� Ȱ��ȭ
        endingIllustration.SetActive(true);

        // �ؽ�Ʈ�� ������ �����ϰ� ����
        StartCoroutine(FadeOutText(congratulationsText));


        // 'Congratulations!' �ؽ�Ʈ�� ������
        congratulationsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutDuration); // 5�� ���� ���

        

        // ũ���� �ؽ�Ʈ�� �ʱ� ��ġ�� ����
        creditText.transform.localPosition = new Vector2(creditText.transform.localPosition.x, 0);

        // ũ���� �ؽ�Ʈ�� ���� ��ũ��
        while (creditText.transform.localPosition.y < scrollHeight)
        {
            creditText.transform.localPosition += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
            yield return null;
        }

        // ��ũ���� �Ϸ�Ǹ� ���� �Ϸ���Ʈ ��Ȱ��ȭ
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

        text.gameObject.SetActive(false); // ���̵� �ƿ� �� �ؽ�Ʈ ��Ȱ��ȭ
    }

    public void ToMainMenu()
    {
        Hub.StageManager.ToScene("Menu");
    }











}
