using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public void ToScene(string sceneName)
    {
        // Add Transition Here
        Hub.PlayerStatus.isInPortal = false;
        // 여기에 허브 기능 추가함 
        SceneManager.LoadScene(sceneName);
        
    }


}
