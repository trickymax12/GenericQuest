using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //Movement Variables
    public float moveSpeed;
    public float horizontalInput;

    //Jumping
    public bool isOnGround = true;
    public float jumpForce;

    //Game Manager
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);

        //Flip if facing left
        if(horizontalInput < 0)
        {
            sr.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        
        //Jump
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    public void Hurt()
    {
        gm.Respawn();
    }
}
