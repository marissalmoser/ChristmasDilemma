using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    bool interact;
    SpriteRenderer sr;
    ParticleSystem ps;

    public GameObject KeyText;
    public GameObject KeySymbol;

    public bool Key;

    private void Start()
    {
        //getting components
        sr = gameObject.GetComponent<SpriteRenderer>();
        ps = gameObject.GetComponent<ParticleSystem>();

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
            if (KeySymbol != null)
            {
                KeySymbol.SetActive(true);
            }
        }
        else
        {
            if (KeySymbol != null)
            {
                KeySymbol.SetActive(false);
            }
        }

        if(Key && !interact)
        {
            Destroy(ps);
        }
    }

    void KeyFound()
    {
        sr.enabled = !sr.enabled;
        Key = true;
        if (ps != null)
        {
            KeyText.SetActive(true);
        }
        Invoke("KeyTextOff", 3);
        if (ps != null)
        {
            var em = ps.emission;
            em.enabled = false;
        }
    }

    void KeyTextOff()
    {
        Destroy(KeyText);
    }

    //check if player is by the object
    void OnTriggerEnter2D(Collider2D target)
    {
        interact = true;

        if(ps != null)
        {
            var em = ps.emission;
            em.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        interact = false;

        if (ps != null)
        {
            var em = ps.emission;
            em.enabled = false;
        }
    }
}
