using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : MonoBehaviour
{
    int enemyLives;
    public GameObject goblinKnife;
    public Transform goblinKnifePos;
    float timer;
    public Animator anmControl;
    public GameObject player;
    public bool isChasing;
    public float chaseDistance;
    void Start()
    {
        enemyLives = 3;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 10)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                ThrowKnife();
                timer = 0;
                anmControl.SetTrigger("isThrowing");
            }
        }
        if(enemyLives == 0)
        {
            Destroy(gameObject);
        }
        if(timer > 2)
        {
            ThrowKnife();
            timer = 0;
            anmControl.SetTrigger("isThrowing");
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ball")
        {
            enemyLives = enemyLives - 1;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "PurpleBall")
        {
            enemyLives = enemyLives - 3;
            Destroy(other.gameObject);
        }
    }

    void ThrowKnife()
    {
        Instantiate(goblinKnife, goblinKnifePos.position, Quaternion.identity);
    }
}
