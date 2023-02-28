using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD : MonoBehaviour
{
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parent.GetComponent<enemywalk>().headCollision = true;
        }
    }
}
