using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    pause,
}

public class GameManager : MonoBehaviour
{
    public GameState CurrentGameState;
}
