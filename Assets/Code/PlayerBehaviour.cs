using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2();

    Rigidbody2D rb2D;

    public float MoveSpeed;
    float moveHorizontal;
    float moveVertical;

    public bool HasLanded;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        HasLanded = true;
    }

    void FixedUpdate ()
    {
        //check if moving
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal < 0f || moveHorizontal > 0f)
        {
            //move horizontally
            rb2D.AddForce(new Vector2(moveHorizontal * MoveSpeed, 0f));
        }
        
        if (HasLanded && Input.GetKeyDown(KeyCode.W))
        {
            //jump
            rb2D.AddForce(jumpForce);
            HasLanded = false;
        }
        
        if (moveVertical < 0f)
        {
            //fall through platforms
        }
    }

}
