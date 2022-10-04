using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    PlayerBehaviour pb;

    private void Start()
    {
        //getting the player game object
        GameObject player = GameObject.Find("Player");

        //Accessing the player behaviour Component
        pb = player.GetComponent<PlayerBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pb.HasLanded = true;
    }
}
