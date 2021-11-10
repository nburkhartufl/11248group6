using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using powergenerators;

namespace generatortypes
{
    public class GeneratorTypes : MonoBehaviour
    {
        private Dictionary<string, bool> generators = new Dictionary<string, bool>();
        // Start is called before the first frame update
        void Start()
        {
            generators.Add("Faraday Disk", true);
            generators.Add("Electromagnetic Dynamo", false);
            generators.Add("Hydro Turbine", false);
            generators.Add("Solar Cluster", false);
            generators.Add("Wind Farm", false);
            generators.Add("Geothermal Plant", false);
            generators.Add("Diesel Generator", false);
            generators.Add("Coal Generator", false);
            generators.Add("Biofuel Generator", false);
            generators.Add("Natural Gas Generator", false);
            generators.Add("Nuclear Plant", false);
            generators.Add("Antimatter Generator", false);
            generators.Add("Dyson Sphere", false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UnlockGenerator(string type)
        {
            generators[type] = true;
        }

        public bool IsUnlocked(string type)
        {
            return generators[type];
        }
    }
}
