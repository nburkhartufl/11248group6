using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using powergenerators;

namespace techtreecomponent
{
    public class TechTreeComponent : MonoBehaviour
    {
        [SerializeField]
        private Button faraday, electromagnetic, hydro, solar, wind, geothermal, diesel, coal,
            biofuel, naturalGas, nuclear, anti, dyson;

        private Dictionary<Button, TechTreeSlot> techTreeSlots = new Dictionary<Button, TechTreeSlot>();

        private bool loadSave;

        private bool saveGame;

        // Start is called before the first frame update
        void Start()
        {
            InitializeSlots();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitializeSlots()
        {
            techTreeSlots.Add(faraday, new TechTreeSlot(new FaradayGenerator()));
            techTreeSlots[faraday].SetUnlocked();
            techTreeSlots.Add(electromagnetic, new TechTreeSlot(new ElectromagneticGenerator()));
            techTreeSlots.Add(hydro, new TechTreeSlot(new HydroGenerator()));
            techTreeSlots.Add(solar, new TechTreeSlot(new SolarGenerator()));
            techTreeSlots.Add(wind, new TechTreeSlot(new WindGenerator()));
            techTreeSlots.Add(geothermal, new TechTreeSlot(new GeothermalGenerator()));
            techTreeSlots.Add(diesel, new TechTreeSlot(new DieselGenerator()));
            techTreeSlots.Add(coal, new TechTreeSlot(new CoalGenerator()));
            techTreeSlots.Add(biofuel, new TechTreeSlot(new BiofuelGenerator()));
            techTreeSlots.Add(naturalGas, new TechTreeSlot(new NaturalGasGenerator()));
            techTreeSlots.Add(nuclear, new TechTreeSlot(new NuclearGenerator()));
            techTreeSlots.Add(anti, new TechTreeSlot(new AntiGenerator()));
            techTreeSlots.Add(dyson, new TechTreeSlot(new DysonGenerator()));
        }
    }


}
public class TechTreeSlot
{
    private EnergyGenerator energygenerator;

    private bool isLocked;

    public TechTreeSlot(EnergyGenerator generator)
    {
        energygenerator = generator;

        isLocked = true;
    }

    public void SetUnlocked()
    {
        isLocked = false;
    }

    public EnergyGenerator GetGenerator()
    {
        return energygenerator;
    }

    public bool GetLocked()
    {
        return isLocked;
    }
}

