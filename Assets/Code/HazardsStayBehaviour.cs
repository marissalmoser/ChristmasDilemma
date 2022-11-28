using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsStayBehaviour : MonoBehaviour
{
    public bool interact;

    HazardMeterBehaviour hmb;

    public AudioClip HazardSound;
    private Vector2 campos;

    private void Start()
    {
        GameObject HazardMeter = GameObject.Find("HazardFill");
        hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();
    }

    //Investigate: If player is by the object and E is pressed
    private void Update()
    {
        Vector2 campos = Camera.main.transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse0) && interact == true)
        {
            hmb.HazardInc();
            AudioSource.PlayClipAtPoint(HazardSound, campos, 0.25f);
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
