using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour
{
    public GameObject howToJump;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject clone = (GameObject)Instantiate(howToJump, new Vector2(29.38007f, -5.528212f), transform.rotation);
            Destroy(clone, 3f);
        }
    }
}
