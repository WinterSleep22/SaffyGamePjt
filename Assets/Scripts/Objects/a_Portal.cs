using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_Portal : MonoBehaviour
{
    public string stageName;
    public GameObject gateNo;
    public GameObject gateYes;
    public GameObject setInteraction;



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            setInteraction = FindObjectOfType<a_PlayerUI>().gameObject.transform.Find("Interaction").gameObject;
            if (setInteraction != null) setInteraction.SetActive(true);            
            Hub.PlayerStatus.isInPortal = true;
        }
        if(other.tag == "Player" & Hub.InputManager.isInteraction == true)
        {
            Hub.StageManager.ToScene(stageName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Hub.PlayerStatus.isInPortal = false;
        }
    }
}
