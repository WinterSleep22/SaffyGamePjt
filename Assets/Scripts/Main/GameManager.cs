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


    // 이렇게 안 하고 바로 GameState.inGame으로 바꿔버리면
    // 버튼이 바로 활성화 되어서 어색하던데 
    public void Unpause()
    {
        StartCoroutine(UnpauseCor());
    }
    IEnumerator UnpauseCor()
    {
        yield return new WaitForSeconds(1f);
        Hub.GameManager.CurrentGameState = GameState.inGame;
    }


}
