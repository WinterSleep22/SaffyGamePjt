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


    // �̷��� �� �ϰ� �ٷ� GameState.inGame���� �ٲ������
    // ��ư�� �ٷ� Ȱ��ȭ �Ǿ ����ϴ��� 
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
