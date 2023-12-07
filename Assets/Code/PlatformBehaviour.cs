using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float WaitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) ||Input.GetKeyUp(KeyCode.DownArrow))
        {
            WaitTime = 0.5f;
            effector.rotationalOffset = 0;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if(WaitTime <= 0.4)
            {
                effector.rotationalOffset = 180f;
                WaitTime = 0.5f;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
}
