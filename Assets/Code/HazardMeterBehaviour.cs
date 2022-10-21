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

    private void Start()
    {
        HazardMeter = GetComponent<Slider>();
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
        }

        if(MnC == true)
        {
            MnC = false;
        }
    }
}
