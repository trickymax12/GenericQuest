using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetection : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            joelEnemyDeath ed = transform.parent.GetComponent<joelEnemyDeath>();

            ed.isHitOnHead = true;
            ed.player = collision.gameObject;
            ed.Die();
        }
    }
}
