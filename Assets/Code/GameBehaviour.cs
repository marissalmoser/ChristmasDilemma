using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public int Luck;
    public int MaxLuck;

    public GameObject Player;
    PlayerBehaviour Pb;
    Animator Anim;
    PresentMeterBehaviour Pmb;
    HazardMeterBehaviour Hmb;



    void Start()
    {
        //Accessing the player and its components
        GameObject Player = GameObject.Find("Player");
        Pb = Player.GetComponent<PlayerBehaviour>();
        Anim = Player.GetComponent<Animator>();

        //Getting present meter script
        GameObject PresentMeter = GameObject.Find("PresentFill");
        Pmb = PresentMeter.GetComponent<PresentMeterBehaviour>();
        Pmb.PresentsFound = 0;

        //Getting hazard meter script
        GameObject HazardMeter = GameObject.Find("HazardFill");
        Hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();
        Hmb.HazardsFound = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Pmb.PresentsFound == Pmb.MaxPresents)
        {
            //WIN
        }

        if (Hmb.HazardsFound == Hmb.MaxHazards)
        {
            //LOSE
        }
    }

    public void PresentCheck()
    {
        //random number to establish Luck
        Luck = Random.Range(1, MaxLuck);

        if(Luck > 1)
        {
            PresentFound();
        }
    }

    void PresentFound()
    {
        Anim.SetTrigger("Spin");
        Pmb.PresentInc();
        //play sound
    }

}
