using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [Header("Amount")]
    public float increseMP;

    [Header("Position")]
    public Transform spiritPos;
    public Transform skillPos;

    [Header("SpiritList")]
    public GameObject fox;
    public GameObject turtle;
    public GameObject squirrel;

    [Header("SkillList")]
    public GameObject dontChaseFox;
    public GameObject dontRunFromFox;
    public GameObject waterCircle;
    public GameObject throwEmOut;


    [Space]
    public Text tmpTextField;

    public void Awake()
    {
        tmpTextField = Hub.UIManager.tmpTextField;
    }


    public void GatheringEnergy()
    {
        Hub.PlayerStatus.CurrentMP = increseMP;
        tmpTextField.text = "GatheringEngergy";
    }

    public void FireA()
    {
        tmpTextField.text = "FireA!";
        StartCoroutine(FireACor());
        
    }
    IEnumerator FireACor()
    {
        GameObject tmpFox;
        if (Hub.PlayerStatus.currentDirection == Direct.right)
        {
            tmpFox = Instantiate(fox, spiritPos.position + new Vector3(0f, 0.5f, 0), spiritPos.rotation);
            Instantiate(dontChaseFox, skillPos.position + new Vector3(1f, 0.5f, 0), skillPos.rotation);
        }
        else
        {
            tmpFox = Instantiate(fox, spiritPos.position + new Vector3(0f, 0.5f, 0), spiritPos.rotation);
            Instantiate(dontChaseFox, skillPos.position + new Vector3(-1f, 0.5f, 0), skillPos.rotation);
        }
        yield return new WaitForSeconds(3.3f);
        Destroy(tmpFox);
        yield return null;
    }


    public void FireB()
    {
        tmpTextField.text = "FireB!";
        StartCoroutine(FireBCor());
    }
    IEnumerator FireBCor()
    {
        GameObject tmpFox = Instantiate(fox, spiritPos.position, spiritPos.rotation);
        Instantiate(dontRunFromFox, skillPos.position, skillPos.rotation);
        yield return new WaitForSeconds(0.6f);
        Destroy(tmpFox);
        yield return null;
    }




    public void WaterA()
    {
        tmpTextField.text = "WaterA!";
        StartCoroutine(WaterACor());
    }

    IEnumerator WaterACor()
    {
        GameObject tmpTurtle = Instantiate(turtle, skillPos.position + new Vector3(0, 1f, 0), skillPos.rotation);
        Instantiate(waterCircle, skillPos.position + new Vector3(0, 1f, 0), skillPos.rotation);
        yield return new WaitForSeconds(3.5f);
        Destroy(tmpTurtle);
        yield return null;
    }

    public void WaterB()
    {
        tmpTextField.text = "WaterB";
    }
    public void WindA()
    {
        tmpTextField.text = "WindA!";
        StartCoroutine(WindACor());
    }
    IEnumerator WindACor()
    {
        GameObject tmpSquirrel = Instantiate(squirrel, spiritPos.position + new Vector3(0, 0f, 0), spiritPos.rotation);
        if (Hub.PlayerStatus.currentDirection == Direct.right)
        {
            Instantiate(throwEmOut, skillPos.position + new Vector3(1f, 0f, 0), skillPos.rotation);
        }
        else
        {
            Instantiate(throwEmOut, skillPos.position + new Vector3(-1f, 0f, 0), skillPos.rotation);
        }
        yield return new WaitForSeconds(3f);
        Destroy(tmpSquirrel);
        yield return null;
    }

    public void WindB()
    {
        tmpTextField.text = "WindB!";
    }
    public void WindC()
    {
        tmpTextField.text = "WindC!";
    }
}
