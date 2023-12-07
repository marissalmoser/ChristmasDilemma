using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2();

    Rigidbody2D rb2D;
    Animator anim;

    public float MoveSpeed;
    float moveHorizontal;

    public bool HasLanded;
    public LayerMask GroundLayer;
    public float PlayerHeight;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //walking behaviour
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (moveHorizontal < 0f)
        {
            //move left
            rb2D.AddForce(new Vector2(moveHorizontal * MoveSpeed * Time.deltaTime, 0f));
            anim.SetBool("Walk Left",true);
        }
        if (moveHorizontal > 0f)
        {
            //move right
            rb2D.AddForce(new Vector2(moveHorizontal * MoveSpeed * Time.deltaTime, 0f));
            anim.SetBool("Walk Right", true);
        }
        if (moveHorizontal == 0)
        {
            anim.SetBool("Walk Right", false);
            anim.SetBool("Walk Left", false);
        }

        //jump behaviour
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, PlayerHeight, GroundLayer);
        if (hit == true)
        {
            HasLanded = true;
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
            rb2D.gravityScale = 1;
        }
        else
        {
            HasLanded = false;
        }

        if (HasLanded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
        {
            //jump
            rb2D.AddForce(jumpForce);
            anim.SetBool("Jump", true);
        }

        //Alter gravity when falling
        if(rb2D.velocity.y < -0.1f)
        {
            rb2D.gravityScale = 15;
            anim.SetBool("Fall", true);
        }
        if(rb2D.velocity.y == 0)// || HasLanded)
        {
            rb2D.gravityScale = 1;
            anim.SetBool("Fall", false);
        }
    }
}
