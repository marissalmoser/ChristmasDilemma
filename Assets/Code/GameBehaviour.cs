using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public GameObject Player;
    Animator anim;
    public PresentMeterBehaviour Pmb;
    public HazardMeterBehaviour Hmb;

    public GameObject WinText;
    public GameObject LoseText;
    public GameObject FireplaceText;

    public bool Fireplace;

    void Start()
    {
        //Accessing the player and its components
        GameObject Player = GameObject.Find("Player");
        anim = Player.GetComponent<Animator>();

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

        //winning and losing
        if(Pmb.PresentMeter.value == Pmb.PresentMeter.maxValue)
        {
            FireplaceText.SetActive(true);
        }
        if (Pmb.PresentMeter.value == Pmb.PresentMeter.maxValue && Fireplace)
        {
            WinText.SetActive(true);
            FireplaceText.SetActive(false);
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

    public void PresentFound()
    {
        Debug.Log("Present found ran");
        anim.SetBool("Present", true);
        Invoke("EndAnimation", 0.5f);
        Pmb.PresentInc();
        //play sound
    }
    void EndAnimation()
    {
        anim.SetBool("Present", false);
    }

    //return to fireplace to win
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fireplace = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Fireplace = false;
    }
}
