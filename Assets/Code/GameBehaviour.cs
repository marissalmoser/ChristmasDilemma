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
    }

}
