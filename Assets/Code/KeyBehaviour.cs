using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    bool interact;
    SpriteRenderer sr;

    public GameObject KeyText;
    public GameObject KeySymbol;

    public bool Key;

    private void Start()
    {
        //getting sprite renderer component
        sr = gameObject.GetComponent<SpriteRenderer>();

        Key = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && interact)
        {
            KeyFound();
        }

        if(Key)
        {
            KeySymbol.SetActive(true);
        }
        else
        {
            KeySymbol.SetActive(false);
        }
    }

    void KeyFound()
    {
        sr.enabled = !sr.enabled;
        Key = true;
        KeyText.SetActive(true);
        Invoke("KeyTextOff", 3);
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
