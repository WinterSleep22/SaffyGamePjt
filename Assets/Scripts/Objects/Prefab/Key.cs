using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D otehr)
    {
        if (otehr.tag == "Player")
        {   
            ParticleSystem newPs = Instantiate(ps, transform.position, transform.rotation);
            newPs.Emit(100);

            Destroy(newPs.gameObject, newPs.main.duration + newPs.main.startLifetime.constantMax);
            Hub.PlayerStatus.isKey = true;
            Destroy(gameObject);  
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
