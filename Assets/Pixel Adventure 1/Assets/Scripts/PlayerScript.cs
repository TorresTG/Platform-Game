using NUnit.Framework;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    SpriteRenderer sprite;
    Rigidbody2D rigidbody;
    BoxCollider2D boxCollider;
    public LayerMask layerMask;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Control
        
        // Left Arrow
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigidbody.linearVelocity = new Vector2(-6f,rigidbody.linearVelocity.y);
                animator.speed = 2f;
            }
            else
            {
                rigidbody.linearVelocity = new Vector2(-3f,rigidbody.linearVelocity.y);
                animator.speed = 1f;
            }
            

        }

        // Right Arrow
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigidbody.linearVelocity = new Vector2(6f,rigidbody.linearVelocity.y);
                animator.speed = 2f;
            }
            else
            {
                rigidbody.linearVelocity = new Vector2(3f,rigidbody.linearVelocity.y);
                animator.speed = 1f;
            }    
        }

        // Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded()){
                sprite.flipX = false;
                rigidbody.linearVelocity = new Vector2(0,4f);
            }
     
        }

        //Animations
        if (isGrounded() && !Input.GetKey(KeyCode.LeftArrow) &&  !Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("status",0);
        }
        else if(isGrounded() && ( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            animator.SetInteger("status",1);
        }
    }


    public bool isGrounded()
    {
        return Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            layerMask
             );
    }
}
