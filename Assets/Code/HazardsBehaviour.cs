using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsBehaviour : MonoBehaviour
{
    public bool interact;

    GameBehaviour Gb;
    HazardMeterBehaviour Hmb;

    private void Start()
    {
        //getting the player behaviour script
        GameObject GameObject = GameObject.Find("GameObject");
        Gb = GameObject.GetComponent<GameBehaviour>();

        GameObject HazardMeter = GameObject.Find("HazardFill");
        Hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();
    }

    //Investigate: If player is by the object and E is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && interact == true)
        {
            Destroy(gameObject);
            Hmb.HazardInc();
            //play sound
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
