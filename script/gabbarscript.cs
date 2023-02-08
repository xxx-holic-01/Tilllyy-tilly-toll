using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabbarscript : MonoBehaviour
{
   Rigidbody2D myRigidBody;
   [SerializeField] float moveSpeed = 1f;
   
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myRigidBody.velocity = new Vector2( moveSpeed,0f);
    }

  void OnTriggerExit2D(Collider2D other) 
  {
    moveSpeed = -moveSpeed;
    FlipEnemyFace();
  }

          
 void  FlipEnemyFace()
 {
transform.localScale= new Vector2(- (Mathf.Sign(myRigidBody.velocity.x)), 1f);

 }


}
