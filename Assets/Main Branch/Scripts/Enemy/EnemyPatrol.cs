using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform groundDetector;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundDetector.position, Vector2.down, .5f);
        if(ground.collider == null)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
