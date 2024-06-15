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
            // Interaction UI 활성화
            setInteraction.SetActive(true);

            // 플레이어가 상호작용 키를 누르면
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
            // Interaction UI 비활성화
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
