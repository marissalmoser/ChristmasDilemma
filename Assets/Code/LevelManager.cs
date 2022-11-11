using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<PresentCheckBehaviour> AllLocations;
    public int TotalPresents;
    public List<PresentCheckBehaviour> SelectedLocations;


    void Start()
    {
        HidePresents();
    }

    void HidePresents()
    {
        for (int i = 0; i < TotalPresents; i++)
        {
            int SelectedLocation = Random.Range(0, AllLocations.Count);
            AllLocations[SelectedLocation].HasPresent = true;
            SelectedLocations.Add(AllLocations[SelectedLocation]);
            AllLocations.RemoveAt(SelectedLocation);

        }
    }
}
