using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }

       // if (collision.gameObject.CompareTag("Enemy"))
        //{
            //Die();
        //}
    //}

} 
    // Additional code or methods could be here...
}
