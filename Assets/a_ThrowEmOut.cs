using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_ThrowEmOut : MonoBehaviour
{
    public int count;
    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        if (Hub.PlayerStatus.currentDirection == Direct.left) this.transform.localScale = new Vector3(-1, 1, 1);
        StartCoroutine(Cor());
    }

    IEnumerator Cor()
    {
        yield return new WaitForSeconds(0.2f);
        if (count != 0)
        {
            count = count - 1;
            Instantiate(this, pos.position, pos.rotation);
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
