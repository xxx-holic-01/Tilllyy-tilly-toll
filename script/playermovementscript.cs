using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playermovementscript : MonoBehaviour
{


[SerializeField]  float runSpeed =10f;
[SerializeField] float jumpSpeed=5f;
[SerializeField]  float climbSpeed = 5f;
[SerializeField] Vector2 deadkick = new Vector2(10f,10f);
Vector2 moveInput;

[SerializeField] GameObject bullet;
[SerializeField] Transform gun;
Rigidbody2D myRigidbody;
Animator myAnimator;
CapsuleCollider2D myBodyCollider;
BoxCollider2D myFeetCollider;
float gravityScaleAtStart ;

//bool as enemy hit the player it will die so we will set the bool to .....
bool isAlive = true;


        void Start()
    {
      myRigidbody=GetComponent<Rigidbody2D>();
      myAnimator=GetComponent<Animator>();
      myFeetCollider = GetComponent<BoxCollider2D>();
      myBodyCollider = GetComponent<CapsuleCollider2D>();
gravityScaleAtStart= myRigidbody.gravityScale;
    }

   
    void Update()
    {
        if(!isAlive){return;}
        Run();
        FilpSprite();
        climbladder();
        Die();
        

    }

     void OnFire(InputValue value)
    {
    if(!isAlive){return;}
    Instantiate(bullet , gun.position , transform.rotation);
    }

     void OnMove(InputValue value)
     {
        if(!isAlive){return;}

        moveInput= value.Get<Vector2>();
        Debug.Log(moveInput);
     }

     void OnJump(InputValue value)
     {

        if(!isAlive){return;}

        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}

if(value.isPressed )
{
    //do thik
    myRigidbody.velocity += new Vector2(0f,jumpSpeed);
}
     }

void Run()
{
    Vector2 playerVelocity = new Vector2( moveInput.x * runSpeed , myRigidbody.velocity.y);
    myRigidbody.velocity= playerVelocity;
    bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

    myAnimator.SetBool("is running" , playerHasHorizontalSpeed);

}
void FilpSprite()
{
    bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    if(playerHasHorizontalSpeed)
    {
transform.localScale= new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);

    }
}
  

//ladder
void climbladder()
{
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        
        {
            myRigidbody.gravityScale=gravityScaleAtStart;
            myAnimator.SetBool("is climbing",false);
            return;
            
        }
    
    Vector2 climbvelocity = new Vector2(  myRigidbody.velocity.x  , moveInput.y*climbSpeed);
    myRigidbody.velocity= climbvelocity;
    myRigidbody.gravityScale=0f;
    bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;


    myAnimator.SetBool("is climbing" , playerHasVerticalSpeed);
}

void Die()
{
    if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("enemies" , " Hazards")))
    {
        isAlive = false;
        myAnimator.SetTrigger("Dying");
        myRigidbody.velocity = deadkick;
        FindObjectOfType<gamesession>().ProcessPlayerDeath();
    }
}

}
