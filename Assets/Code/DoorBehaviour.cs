using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    bool interact;
    KeyBehaviour kb;

    private void Start()
    {
        GameObject KeySpot = GameObject.FindGameObjectWithTag("Key");
        kb = KeySpot.GetComponent<KeyBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interact && kb.Key)
        {
            Destroy(gameObject);
            kb.Key = false;
            Destroy(kb.KeySymbol);
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
