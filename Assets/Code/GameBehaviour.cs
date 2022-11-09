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
    Animator anim;
    public PresentMeterBehaviour Pmb;
    public HazardMeterBehaviour Hmb;

    public GameObject WinText;
    public GameObject LoseText;

    public bool Fireplace;

    void Start()
    {
        //Accessing the player and its components
        GameObject Player = GameObject.Find("Player");
        Pb = Player.GetComponent<PlayerBehaviour>();
        anim = Player.GetComponent<Animator>();

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
        if (Pmb.PresentMeter.value == Pmb.PresentMeter.maxValue && Fireplace)
        {
            WinText.SetActive(true);

            Invoke("NextLevel", 3);
  
        }

        if (Hmb.HazardMeter.value == Hmb.HazardMeter.maxValue)
        {
            LoseText.SetActive(true);
        }
    }

    void NextLevel()
    {
        WinText.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        anim.SetTrigger("Spin");
        Pmb.PresentInc();
        //play sound
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fireplace = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Fireplace = false;
    }
}
