using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    bool interact;
    public bool Key;
    SpriteRenderer sr;
    EdgeCollider2D ec;

    private void Start()
    {
        //getting components
        sr = gameObject.GetComponent<SpriteRenderer>();
        ec = gameObject.GetComponent<EdgeCollider2D>();

        Key = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interact && Key)
        {
            sr.enabled = !sr.enabled;
            ec.enabled = !ec.enabled;
        }
    }

    //check if player is by the object
    void OnTriggerEnter2D(Collider2D target)
    {
        interact = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        interact = false;
    }
}
