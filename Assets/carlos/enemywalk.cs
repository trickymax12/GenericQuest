using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywalk : MonoBehaviour
{
    public float speed = 2;
    public bool isdead = false;
    public Animator animator;
    public Transform groundDetector;
    public bool headCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        groundDetector = gameObject.transform.Find("groundDetector").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        RaycastHit2D groundRay = Physics2D.Raycast(groundDetector.position, Vector2.down, 1f);
        if(groundRay.collider == null)
        {
            transform.Rotate(0f, 180f, 0f);
        }
         
    }
    IEnumerator Destroyenemy()
    {
        yield return new WaitForSeconds(1);
        Destroy (gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!headCollision)
            {
                collision.gameObject.GetComponent<player>().Hurt();
            }
            else
            {
                StartCoroutine(Destroyenemy());
                animator.SetBool("isdead", true);
            }
        }
    }
}
