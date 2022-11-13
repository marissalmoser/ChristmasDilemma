using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    bool interact;
    SpriteRenderer sr;
    DoorBehaviour db;

    public GameObject KeyText;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        //getting door behaviour script
        GameObject Door = GameObject.FindGameObjectWithTag("Door");
        db = Door.GetComponent<DoorBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interact)
        {
            sr.enabled = !sr.enabled;
            db.Key = true;
            KeyText.SetActive(true);
            Invoke("KeyTextOff", 3);
        }
    }

    void KeyTextOff()
    {
        KeyText.SetActive(false);
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
