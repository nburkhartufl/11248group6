using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using powergenerators;
using counterscomponent;
using generatortypes;

namespace techtreecomponent
{
    public class TechTreeComponent : MonoBehaviour
    {
        [SerializeField]
        private Button faraday, electromagnetic, hydro, solar, wind, geothermal, diesel, coal,
            biofuel, naturalGas, nuclear, anti, dyson;

        [SerializeField]
        private Sprite farDisk, electroGen, hydroTur, solCluster, windFarm, geoPlant, dieselGen, coalGen, bioGen, natGasGen, nuclearPlant, antiGen,
            dysonSphere, unlock, lockImg;

        [SerializeField]
        private TextMeshProUGUI requirements, description, maxCounter;

        [SerializeField]
        private GameObject menu;

        private Dictionary<Button, TechTreeSlot> techTreeSlots = new Dictionary<Button, TechTreeSlot>();

        private bool loadSave;

        private bool saveGame;

        private GeneratorTypes gt = new GeneratorTypes();

        // Start is called before the first frame update
        void Start()
        {
            InitializeSlots();
            Update();
            InvokeRepeating("UpdateSpriteFamilies", 0, 1);
        }

        // Update is called once per frame
        void Update()
        {
            maxCounter.text = "TOTAL ENERGY PRODUCED: " + FindObjectOfType<CounterComponent>().GetMaxEnergyCount() +
                "\nTOTAL POLLUTION PRODUCED: " + FindObjectOfType<CounterComponent>().GetMaxPollutionCount();
            foreach(KeyValuePair<Button, TechTreeSlot> entry in techTreeSlots)
            {
                if(entry.Value.GetLocked() == true &&
                    FindObjectOfType<CounterComponent>().GetMaxEnergyCount() >= entry.Value.GetGenerator().GetUnlock()[0] &&
                    FindObjectOfType<CounterComponent>().GetMaxPollutionCount() >= entry.Value.GetGenerator().GetUnlock()[1])
                {
                    entry.Value.SetUnlocked();
                    gt.UnlockGenerator(entry.Value.GetGenerator().GetTypeExplicit());
                }
            }
        }

        void InitializeSlots()
        {
            techTreeSlots.Add(faraday, new TechTreeSlot(new FaradayGenerator()));
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

        public void UpdateSpriteFamilies()
        {
            foreach (KeyValuePair<Button, TechTreeSlot> entry in techTreeSlots)
            {
                if (!entry.Value.GetLocked())
                {
                    var genColor = entry.Key.transform.Find("generator").GetComponent<Image>().color;
                    genColor.a = 1f;
                    entry.Key.transform.Find("generator").GetComponent<Image>().color = genColor;
                }
            }
        }

        public void OpenMenu(Button butt, Sprite img)
        {
            menu.transform.Find("generatorImage").GetComponent<Image>().sprite = img;
            if (techTreeSlots[butt].GetLocked())
            {
                string energyText = techTreeSlots[butt].GetGenerator().GetUnlock()[0].ToString();
                string pollutionText = techTreeSlots[butt].GetGenerator().GetUnlock()[1].ToString();
                requirements.text = "ENERGY REQUIREMENT: " + energyText + "\nPOLLUTION REQUIREMENT: " + pollutionText;
                menu.transform.Find("lock").GetComponent<Image>().sprite = lockImg;
            }
            else
            {
                string energyText = techTreeSlots[butt].GetGenerator().GetEnergyRate().ToString();
                string pollutionText = techTreeSlots[butt].GetGenerator().GetPollutionRate().ToString();
                requirements.text = "ENERGY PER SECOND: " + energyText + "\nPOLLUTION PER SECOND: " + pollutionText;
                menu.transform.Find("lock").GetComponent<Image>().sprite = unlock;
             }
             menu.SetActive(true);
        }
        public void CloseMenu()
        {
            menu.SetActive(false);
        }

        public void ButtonFaradayLogic()
        {
            description.text = "A Faraday disk is one of the first power generators, composed of a metal disk " +
             "arranged perpendicular to a magnetic field. When the disk is spun, the magnetic field is translated to an electric current.";
            OpenMenu(faraday, farDisk);
        }
        public void ButtonElectromagneticLogic()
        {
            description.text = "An electromagnetic dynamo is very similar to a Faraday disk as it also uses magnetism to " +
                "produce electricity. However, dynamos can do this automatically without someone manually spinning the disk.";
            OpenMenu(electromagnetic, electroGen);
        }
        public void ButtonHydroLogic()
        {
            description.text = "A hydro turbine contains a wheel that, when pushed by flowing water, powers a turbine " +
                " (similar to that of a car) to generate electricity. As such, it creates no pollution.";
            OpenMenu(hydro, hydroTur);
        }
        public void ButtonDieselLogic()
        {
            description.text = "A diesel generator is really a combination of a diesel engine (as seen in many automobiles) " +
                "working in combination with a generator which converts the output of the engine into usable electricity.";
            OpenMenu(diesel, dieselGen);
        }
        public void ButtonBiofuelLogic()
        {
            description.text = "A biofuel generator burns environmentally friendly biological material and uses the energy released to " +
                "create electricity. Most biofuel generators operate in exactly the same way that natural gas generators do.";
            OpenMenu(biofuel, bioGen);
        }
        public void ButtonSolarLogic()
        {
            description.text = "A solar panel is an assembly of photo-voltaic cells mounted in a framework for" +
                "installation. Solar panels use sunlight as a source of energy to generate direct current electricity.";
            OpenMenu(solar, solCluster);
        }
        public void ButtonCoalLogic()
        {
            description.text = "A coal generator burns coal to create energy, which is converted to electricity. Coal " +
            "generators work roughly the same way as both natural gas and biofuel generators, with the key difference being the fuel.";
            OpenMenu(coal, coalGen);
        }
        public void ButtonWindLogic()
        {
            description.text = "A wind farm is composed of many wind turbines that, similar to hydro turbines, use the " +
                "natural flow of air to create electricity. Because of this, they are very renewable but do not create much energy.";
            OpenMenu(wind, windFarm);
        }
        public void ButtonNaturalGasLogic()
        {
            description.text = "Otherwise known as fossil fuels, natural gas generators use previously biological matter " +
                "as energy. Burning natural gas creates high amounts of pollution.";
            OpenMenu(naturalGas, natGasGen);
        }
        public void ButtonGeothermalLogic()
        {
            description.text = "Many areas near the surface of the Earth release heat that comes from much deeper in the " +
                "planet. Geothermal generators convert this thermal energy into electric energy, which is used as power.";
            OpenMenu(geothermal, geoPlant);
        }
        public void ButtonNuclearLogic()
        {
            description.text = "Nuclear generators use the highly unstable process of nuclear fission to create energy. " +
                "Most of these generators use either uranium or plutonium, and split these atoms into smaller atoms, which produces energy.";
            OpenMenu(nuclear, nuclearPlant);
        }
        public void ButtonAntiLogic()
        {
            description.text = "An antimatter generator is a theoretical device. While very little is understood about " +
                "antimatter today, it is widely believed that antimatter generation would be a more effective method of generation than existing methods.";
            OpenMenu(anti, antiGen);
        }
        public void ButtonDysonLogic()
        {
            description.text = "A Dyson sphere is a theoretical device. It is a sphere composed entirely of solar panels " +
                "that encompass the sun, thus producing extremely high amounts of energy far beyond what current methods exist.";
            OpenMenu(dyson, dysonSphere);
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

