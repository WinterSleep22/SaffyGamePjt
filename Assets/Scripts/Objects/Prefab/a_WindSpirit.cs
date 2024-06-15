using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_WindSpirit : MonoBehaviour
{
    public GameObject setInteraction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            setInteraction = FindObjectOfType<a_PlayerUI>().gameObject.transform.Find("Interaction").gameObject;

            if (setInteraction != null)
            {
                setInteraction.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Interaction UI Ȱ��ȭ
            setInteraction.SetActive(true);

            // �÷��̾ ��ȣ�ۿ� Ű�� ������
            if (Hub.InputManager.isInteraction)
            {
                Hub.PlayerStatus.isWindGet = true;
                Debug.Log(Hub.PlayerStatus.isWindGet);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Interaction UI ��Ȱ��ȭ
            setInteraction.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
