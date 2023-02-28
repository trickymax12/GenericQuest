using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float jumpForce = 3f;
    private bool isOnGround = true;
    public float speed = 10f;
    public float horizontalInput;
    public float hurtTime = 2f;
    private bool ishurt = false;
    public float knockBackForce = 2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        } else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));

        if (!ishurt)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;

                anim.SetBool("isOnGround", false);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            anim.SetBool("isOnGround", true);
        }
    }
    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(hurtTime);
        ishurt = false;
        anim.SetBool("ishurt", false);
    }
    public void Hurt()
    {
        ishurt = true;
        anim.SetBool("ishurt", true);
        rb.AddForce((Vector2.left * knockBackForce) + (Vector2.up * knockBackForce), ForceMode2D.Impulse);
        StartCoroutine(HurtDelay());
    }
}
