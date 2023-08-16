using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    Vector2 moveInput;
    float moveSpeed;
    int numberOfJumps;
    public GameObject firePrefab;
    public GameObject purpleFirePrefab;
    public Animator anmControl;
    float jumpForce;
    public int playerLives;
    float timerForAttack;
    public int health;
    public int numOfHears;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 1000f;
        jumpForce = 10f;
        numberOfJumps = 0;
        anmControl = GetComponent<Animator>();
        playerLives = 5;
        timerForAttack = 0;
    }

    void Update()
    {
        HeartSystem();
        if(playerLives == 0)
        {
            SceneManager.LoadScene(0);
            FindObjectOfType<ScenePersist>().ResetScenePersist();
        }
        timerForAttack += Time.deltaTime;
        Movement();
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && numberOfJumps > 0)
        {
            numberOfJumps = numberOfJumps - 1;
            // rb.AddForce(new Vector2(0, jumpForce * Time.deltaTime));
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anmControl.SetBool("Jump", true);
        }
        if(Input.GetKeyDown(KeyCode.Space) && timerForAttack > 0.8f)
        {
            Instantiate(firePrefab, transform.position, firePrefab.transform.rotation);
            anmControl.SetTrigger("Attack2");
            timerForAttack = 0;
        }
        if(Input.GetKeyDown(KeyCode.Z) && timerForAttack > 3f)
        {
            Instantiate(firePrefab, transform.position, firePrefab.transform.rotation);
            Instantiate(firePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), firePrefab.transform.rotation);
            anmControl.SetTrigger("Attack3");
            timerForAttack = 0;
        }
        if(Input.GetKeyDown(KeyCode.X) && timerForAttack > 5f)
        {
            Instantiate(purpleFirePrefab, transform.position, firePrefab.transform.rotation);
            anmControl.SetTrigger("Attack4");
            timerForAttack = 0;
        }
        if(playerLives == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Movement()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool running = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anmControl.SetBool("isRunning", running);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Platform")
        {
            numberOfJumps = 1;
            anmControl.SetBool("Jump", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Goblin Weapon")
        {
            playerLives = playerLives - 1;
            Destroy(other.gameObject);
        }
    }

    void HeartSystem()
    {
        if(playerLives > numOfHears)
        {
            playerLives = numOfHears;
        }
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < playerLives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHears)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
