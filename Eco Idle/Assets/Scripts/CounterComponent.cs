using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using datacounters;
using powerbankcomponent;


namespace counterscomponent
{
    public class CounterComponent : MonoBehaviour
    {

        [SerializeField]
        TextMeshProUGUI energyCount, pollutionCount;

        private EnergyCounter energyCounter = new EnergyCounter();
        private PollutionCounter pollutionCounter = new PollutionCounter();

        //TODO REFERENCE POWERBANKCOMPONENT TO COUNTERCOMPONENT AND SET THE RATE INCREASE TO POWERBANKCOMPONENT

        // Start is called before the first frame update
        void Start() //Deserializes the counters
        {
            energyCounter.SetCurrCounter(0); //set this to a value from serializefile
            energyCounter.SetMaxCounter(0); //set this to a value from serializefile

            pollutionCounter.SetCurrCounter(0); //set this to a value from serializefile
            pollutionCounter.SetMaxCounter(0); //set this to a value from the serializefile

            InitializeCounters();

            InvokeRepeating("CounterUpdate", 0, 1); //Calls CounterUpdate every second;
        }

        public void CounterUpdate()
        {
            energyCounter.SetCurrCounter(FindObjectOfType<PowerBankComponent>().GetEnergyPerSecond());

            pollutionCounter.SetCurrCounter(FindObjectOfType<PowerBankComponent>().GetPollutionPerSecond());

            InitializeCounters();
        }

        public int GetEnergyCount()
        {
            return energyCounter.GetCurrCounter();
        }

        public int GetPollutionCount()
        {
            return pollutionCounter.GetCurrCounter();
        }

        public void SubstractEnergyCount(int offset)
        {
            energyCounter.SubtractCurrCounter(offset);
        }

        public void SubtractPollutionCount(int offset)
        {
            pollutionCounter.SubtractCurrCounter(offset);
        }

        public void InitializeCounters()
        {
            energyCount.text = energyCounter.GetCurrCounter().ToString();
            pollutionCount.text = pollutionCounter.GetCurrCounter().ToString();
        }
    }
}