using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_DoNotChaseFox : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        if (Hub.PlayerStatus.currentDirection == Direct.left) this.transform.localScale = new Vector3(-1,1,1);
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {

        yield return new WaitForSeconds(2.5f);
        animator.SetBool("isOff", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
