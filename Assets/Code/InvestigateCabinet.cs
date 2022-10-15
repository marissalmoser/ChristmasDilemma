using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateCabinet : MonoBehaviour
{
    SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider target)
    {
        if (target.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            sr.enabled = !sr.enabled;
        }
    }
}
