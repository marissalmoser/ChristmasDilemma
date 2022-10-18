using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentMeterBehaviour : MonoBehaviour
{
    public Slider PresentMeter;
    public int PresentsFound;

    private void Start()
    {
        PresentMeter = GetComponent<Slider>();
    }

    public void SetMaxPresents(int maxPresents)
    {
        PresentMeter.value = maxPresents;
        PresentMeter.value = maxPresents;
    }

    //Credit to Dani Krossing's YouTube ^

    public void PresentInc()
    {
        PresentsFound++;
        PresentMeter.value = PresentsFound;
    }
}
