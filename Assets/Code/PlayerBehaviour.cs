using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2();

    Rigidbody2D rb2D;
    Animator Anim;

    public float MoveSpeed;
    float moveHorizontal;

    public bool HasLanded;

    public GameObject Platforms;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        HasLanded = true;

        GameObject Platforms = GameObject.Find("Platforms");
    }

    void Update()
    {
        //check if moving
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (moveHorizontal < 0f || moveHorizontal > 0f)
        {
            //move horizontally
            rb2D.AddForce(new Vector2(moveHorizontal * MoveSpeed * Time.deltaTime, 0f));
            Anim.SetBool("Walk",true);
        }

        if (moveHorizontal == 0)
        {
            Anim.SetBool("Walk", false);
        }

        if (HasLanded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
        {
            //jump
            rb2D.AddForce(jumpForce);
            HasLanded = false;
        }

        //Alter gravity when falling
        if(rb2D.velocity.y < -0)
        {
            rb2D.gravityScale = 10;
        }

        if(rb2D.velocity.y == 0)
        {
            rb2D.gravityScale = 1;
        }

        //platform behavior
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Platforms.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Platforms.SetActive(true);
        }
    }
}
