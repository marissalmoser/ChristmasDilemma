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

    public GameObject WinText;
    public GameObject LoseText;

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
        Pmb.MaxPresents = 5;

        //Getting hazard meter script
        GameObject HazardMeter = GameObject.Find("HazardFill");
        Hmb = HazardMeter.GetComponent<HazardMeterBehaviour>();
        Hmb.HazardsFound = 0;
        Hmb.MaxHazards = 8;
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

        //winning and losing
        if (Pmb.PresentMeter.value == Pmb.PresentMeter.maxValue)
        {
            WinText.SetActive(true);
        }

        if (Hmb.HazardMeter.value == Hmb.HazardMeter.maxValue)
        {
            LoseText.SetActive(true);
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

    public void PresentFound()
    {
        Anim.SetTrigger("Spin");
        Pmb.PresentInc();
        //play sound
    }

}
