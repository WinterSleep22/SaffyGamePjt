using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;  
	[Range(0.0f, 20.0f)]  
	public float moveSpeed = 3.0f;  
	public Transform currentPoint;  
	public Transform[] points;  
	public int pointSelection; 
	public Rigidbody2D rb;
    private bool isPause;
    // 이 플랫폼에 타고 나서야 움직이는지 여부 
    public bool isModeHopOn;
    public float pauseDuration;
    


	void Awake () {

		currentPoint = points[pointSelection];
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        if (!isPause & !isModeHopOn) MoveObj();

    }

    void MoveObj()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if (platform.transform.position == currentPoint.position)
        {
            isPause = true;            
            pointSelection++;
            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
            StartCoroutine(WaitForAWhile());
        }
    }

    IEnumerator WaitForAWhile()
    {
        yield return new WaitForSeconds(pauseDuration);
        isPause = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.SetParent(transform);
        if (isModeHopOn) isModeHopOn = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }



}
