using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardMeterBehaviour : MonoBehaviour
{
    public Slider HazardMeter;
    public int HazardsFound;
    public int MaxHazards;

    public bool MnC;

    public GameObject MnCSymbol;

    Animator anim;

    private void Start()
    {
        HazardMeter = GetComponent<Slider>();

        GameObject Player = GameObject.Find("Player");
        anim = Player.GetComponent<Animator>();
    }

    public void SetMaxPresents(int MaxHazards)
    {
        HazardMeter.maxValue = MaxHazards;
        HazardMeter.value = MaxHazards;
    }

    //Credit to Dani Krossing's YouTube ^

    public void HazardInc()
    {
        if(MnC == false)
        {
            HazardsFound++;
            HazardMeter.value = HazardsFound;
            MnC = false;
            anim.SetBool("Hazard", true);
            Invoke("EndAnimation", 0.5f);
        }

        if (MnC == true)
        {
            MnC = false;
            MnCSymbol.SetActive(false);
        }
    }

    void EndAnimation()
    {
        anim.SetBool("Hazard", false);
    }
}
