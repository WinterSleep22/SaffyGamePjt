using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class a_Portal : MonoBehaviour
{
    public string stageName;
    public bool isGateForClear = false;
    private bool isGateUsing = false;
    public Sprite gateNo;
    public Sprite gateYes;
    [HideInInspector] public GameObject setInteraction;

    private void FixedUpdate()
    {
        if (Hub.PlayerStatus.isKeyAll)
        {
            this.GetComponent<SpriteRenderer>().sprite = gateYes;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" &
            Hub.PlayerStatus.isKeyAll)
        {
            setInteraction = FindObjectOfType<a_PlayerUI>().gameObject.transform.Find("Interaction").gameObject;
            if (setInteraction != null) setInteraction.SetActive(true);            
            Hub.PlayerStatus.isInPortal = true;
        }
        // 이거 isGateUsing 사용해서 여러 번 반복되지 않게 하기
        if(!isGateUsing &
           other.tag == "Player" & 
           Hub.InputManager.isInteraction == true &
           Hub.PlayerStatus.isKeyAll &
           Hub.PlayerStatus.currentPlayerState != PlayerState.skill)
        {
            isGateUsing = true;
            if (isGateForClear) Hub.StageManager.GameOff(stageName);
            else Hub.StageManager.ToScene(stageName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Hub.PlayerStatus.isInPortal = false;
            setInteraction.SetActive(false);
        }
    }
}
