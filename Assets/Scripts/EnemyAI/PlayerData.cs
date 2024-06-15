using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance   // singleton ==> Hub 에 이식!!
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerData>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("PlayerData");
                    instance = instanceContainer.AddComponent<PlayerData>();
                }
            }
            return instance;
        }

    }
    private static PlayerData instance;

    public GameObject Player;
}
