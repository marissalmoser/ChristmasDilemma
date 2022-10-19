using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardMeterBehaviour : MonoBehaviour
{
    public Slider HazardMeter;
    public int HazardsFound;
    public int MaxHazards;

    private void Start()
    {
        HazardMeter = GetComponent<Slider>();
    }

    public void SetMaxPresents(int MaxHazards)
    {
        HazardMeter.value = MaxHazards;
        HazardMeter.value = MaxHazards;
    }

    //Credit to Dani Krossing's YouTube ^

    public void HazardInc()
    {
        HazardsFound++;
        HazardMeter.value = HazardsFound;
    }
}
