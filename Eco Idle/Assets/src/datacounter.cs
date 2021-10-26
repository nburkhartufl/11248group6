using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace datacounters
{

    abstract class DataCounter
    {
        protected int currCounter;

        protected int maxCounter;

        public int GetCurrCounter()
        {
            return currCounter;
        }
        public int GetMaxCounter()
        {
            return maxCounter;
        }
        public void SetCurrCounter(int offset)
        {
            currCounter = currCounter + offset;

            SetMaxCounter(offset);
        }
        public void SetMaxCounter(int offset)
        {
            maxCounter = maxCounter + offset;
        }
        public void SubtractCurrCounter(int offset)
        {
            currCounter = currCounter - offset;
        }

    }

    class EnergyCounter : DataCounter
    {
        public EnergyCounter()
        {
            currCounter = 0;

            maxCounter = 0;
        }
    }

    class PollutionCounter : DataCounter
    {
        public PollutionCounter()
        {
            currCounter = 0;

            maxCounter = 0;
        }
    }





}
