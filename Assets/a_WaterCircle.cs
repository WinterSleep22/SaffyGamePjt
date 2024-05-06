using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direct
{
    left,
    right
}

public class a_WaterCircle : MonoBehaviour
{
    public Direct Direction;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Skill());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x + 0.005f, this.transform.position.y);
    }

    IEnumerator Skill()
    {
        while (this.transform.localScale.x < 18)
        {
            this.transform.localScale = new Vector2(this.transform.localScale.x + 0.35f, this.transform.localScale.y + 0.35f);
            yield return null;
        }
        yield return new WaitForSeconds(3f);

        while (this.transform.localScale.x > 0.5f)
        {
            this.transform.localScale = new Vector2(this.transform.localScale.x - 0.5f, this.transform.localScale.y - 0.5f);
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
