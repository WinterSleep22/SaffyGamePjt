using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int[] RequiredKeyAmount;


    public void ToScene(string sceneName)
    {
        // Add Transition Here
        Hub.PlayerStatus.isInPortal = false;
        Hub.PlayerStatus.isKey = false;
        Hub.PlayerStatus.KeyCount = 0;
        // ���⿡ ��� ��� �߰��� 
        SceneManager.LoadScene(sceneName);
        
    }


}
