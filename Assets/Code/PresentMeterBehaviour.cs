using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentMeterBehaviour : MonoBehaviour
{
    public Slider PresentMeter;
    public int PresentsFound;
    public int MaxPresents;

    private void Start()
    {
        PresentMeter = GetComponent<Slider>();
    }

    public void SetMaxPresents(int MaxPresents)
    {
        PresentMeter.value = MaxPresents;
        PresentMeter.value = MaxPresents;
    }

    //Credit to Dani Krossing's YouTube ^

    public void PresentInc()
    {
        PresentsFound++;
        PresentMeter.value = PresentsFound;
    }
}
