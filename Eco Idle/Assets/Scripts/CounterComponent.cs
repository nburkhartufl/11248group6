using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using datacounters;
using powerbankcomponent;

public class CounterComponent : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI energyCount, pollutionCount;

    private EnergyCounter energyCounter = new EnergyCounter();
    private PollutionCounter pollutionCounter = new PollutionCounter();

    public GameObject otherGameObject;

    //TODO REFERENCE POWERBANKCOMPONENT TO COUNTERCOMPONENT AND SET THE RATE INCREASE TO POWERBANKCOMPONENT

    // Start is called before the first frame update
    void Start() //Deserializes the counters
    {
        energyCounter.SetCurrCounter(1); //set this to a value from serializefile
        energyCounter.SetMaxCounter(1); //set this to a value from serializefile

        pollutionCounter.SetCurrCounter(1); //set this to a value from serializefile
        pollutionCounter.SetMaxCounter(1); //set this to a value from the serializefile

        InitializeCounters();

        InvokeRepeating("CounterUpdate", 0, 1); //Calls CounterUpdate every second;
    }

    public void CounterUpdate()
    {
        energyCounter.SetCurrCounter(1);
        pollutionCounter.SetCurrCounter(1);

        InitializeCounters();
    }

    public void InitializeCounters()
    {
        energyCount.text = energyCounter.GetCurrCounter().ToString();
        pollutionCount.text = pollutionCounter.GetCurrCounter().ToString();
    }
}