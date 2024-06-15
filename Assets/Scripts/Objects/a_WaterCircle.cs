using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_WaterCircle : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (Hub.PlayerStatus.currentDirection == Direct.left) moveSpeed = -moveSpeed;
        StartCoroutine(Skill());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x + moveSpeed, this.transform.position.y);
    }

    IEnumerator Skill()
    {
        while (this.transform.localScale.x < 1)
        {
            this.transform.localScale = new Vector2(this.transform.localScale.x + 0.035f, this.transform.localScale.y + 0.035f);
            yield return null;
        }
        yield return new WaitForSeconds(3f);

        /*
        while (this.transform.localScale.x > 0.5f)
        {
            this.transform.localScale = new Vector2(this.transform.localScale.x - 0.05f, this.transform.localScale.y - 0.05f);
            yield return null;
        }*/
        animator.SetBool("isOff", true);
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
