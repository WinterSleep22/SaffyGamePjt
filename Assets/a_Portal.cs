using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_Portal : MonoBehaviour
{
    public string stageName;
    public GameObject goodToGo;



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            goodToGo.SetActive(true);
            Hub.PlayerStatus.isInPortal = true;
        }
        if(other.tag == "Player" & Hub.InputManager.isUP == true)
        {
            Hub.StageManager.ToScene(stageName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            goodToGo.SetActive(false);
            Hub.PlayerStatus.isInPortal = false;
        }
    }
}
