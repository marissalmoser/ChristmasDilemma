using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    bool interact;
    SpriteRenderer sr;
    DoorBehaviour Db;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        //getting door behaviour script
        GameObject Door = GameObject.FindGameObjectWithTag("Door");
        Db = Door.GetComponent<DoorBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && interact)
        {
            sr.enabled = !sr.enabled;
            Db.Key = true;
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
