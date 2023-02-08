using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullete : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 20f;
    playermovementscript player;
    float xSpeed;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<playermovementscript>();

        xSpeed = player.transform.localScale.x*bulletSpeed;
    }

    

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed,0f);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "enemy") 
       {
        Destroy(other.gameObject);
       }
       Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
