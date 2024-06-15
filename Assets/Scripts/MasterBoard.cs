using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBoard : MonoBehaviour
{
    public void IncreaseOne()
    {
        Hub.PlayerStatus.SetCurrentHP(0.5);
    }

    public void DecreaseOne()
    {
        Hub.PlayerStatus.SetCurrentHP(-0.5);
    }

}
