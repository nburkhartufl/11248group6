using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using powergenerators;
using counterscomponent;
using generatortypes;
using powerbankcomponent;


    public class ShopComponent : MonoBehaviour
    {

        [SerializeField]
        private Button faraday, electromagnetic, hydro, solar, wind, geothermal, diesel, coal,
            biofuel, naturalGas, nuclear, anti, dyson, closeBtn, purchaseBtn;

        [SerializeField]
        private Sprite farDisk, electroGen, hydroTur, solCluster, windFarm, geoPlant, dieselGen, coalGen, bioGen, natGasGen, nuclearPlant, antiGen,
            dysonSphere, unlock, lockImg;
        
        [SerializeField]
        private TextMeshProUGUI requirements, description, maxCounter, title;

        [SerializeField]
        private GameObject menu;

        private Dictionary<Button, shopSlot> shopSlots = new Dictionary<Button, shopSlot>();

        private bool loadSave;

        private bool saveGame;

        // Start is called before the first frame update
        void Start()
        {
            InitializeSlots();
            Update();   
        }

        // Update is called once per frame
        void Update()
        {
            maxCounter.text = "TOTAL ENERGY PRODUCED: " + FindObjectOfType<CounterComponent>().GetMaxEnergyCount() +
            "\nTOTAL POLLUTION PRODUCED: " + FindObjectOfType<CounterComponent>().GetMaxPollutionCount();
        }
        public void OpenMenu(Button butt, Sprite img)
        {
            menu.transform.Find("generatorImage").GetComponent<Image>().sprite = img;
            shopSlots[butt].isSelected = true;
            string energyText = shopSlots[butt].getPrice().ToString();
            string pollutionText = shopSlots[butt].GetGenerator().GetUnlock()[1].ToString();
            string name = shopSlots[butt].getName();
            requirements.text = "ENERGY REQUIREMENT: "+energyText;
            title.text = name;
            menu.SetActive(true);
        }
        public void CloseMenu()
        {
            allFalse();
            menu.SetActive(false);
        }

        public void Purchase()
        {
            foreach(KeyValuePair<Button, shopSlot> entry in shopSlots)
            {
                if(entry.Value.isSelected){
                    if(FindObjectOfType<PowerBankComponent>().GetSlotsAvailable()>0 && FindObjectOfType<CounterComponent>().GetEnergyCount() >= entry.Value.getPrice())
                    {
                        FindObjectOfType<CounterComponent>().SubstractEnergyCount(entry.Value.getPrice());
                        FindObjectOfType<PowerBankComponent>().AddGenerator(entry.Value.GetGenerator());
                        entry.Value.count++;
                        menu.SetActive(false);
                        entry.Value.isSelected=false;
                    }
                }

            }
    
        }
        
        public void allFalse(){
            foreach(KeyValuePair<Button, shopSlot> entry in shopSlots)
            {
                entry.Value.isSelected=false;
            }
        }


        void InitializeSlots()
        {
            shopSlots.Add(faraday, new shopSlot(new FaradayGenerator(), 1, "Faraday Generator", false, 0));
            shopSlots.Add(electromagnetic, new shopSlot(new ElectromagneticGenerator(), 0, "Electromagnetic Dynamo", false, 400));
            shopSlots.Add(hydro, new shopSlot(new HydroGenerator(), 0, "Hydro Turbine", false, 65000));
            shopSlots.Add(solar, new shopSlot(new SolarGenerator(), 0, "Solar Cluster", false, 100000));
            shopSlots.Add(wind, new shopSlot(new WindGenerator(), 0, "Wind Farm", false, 180000));
            shopSlots.Add(geothermal, new shopSlot(new GeothermalGenerator(), 0, "Geothermal Plant", false, 450000));
            shopSlots.Add(diesel, new shopSlot(new DieselGenerator(), 0, "Diesel Generator", false, 40000));
            shopSlots.Add(coal, new shopSlot(new CoalGenerator(), 0, "Coal Plant", false, 45000));
            shopSlots.Add(biofuel, new shopSlot(new BiofuelGenerator(), 0, "Biofuel Generator", false, 25000));
            shopSlots.Add(naturalGas, new shopSlot(new NaturalGasGenerator(), 0, "Natural Gas Generator", false, 90000));
            shopSlots.Add(nuclear, new shopSlot(new NuclearGenerator(), 0, "Nuclear Plant", false, 1200000));
            shopSlots.Add(anti, new shopSlot(new AntiGenerator(), 0, "Antimatter Generator", false, 99999999));
            shopSlots.Add(dyson, new shopSlot(new DysonGenerator(), 0, "Dyson Sphere", false, 999999999));
        }

        public void ButtonFaradayLogic()
        {
        
            OpenMenu(faraday, farDisk);
        }
        public void ButtonElectromagneticLogic()
        {
            
            OpenMenu(electromagnetic, electroGen);
        }
        public void ButtonHydroLogic()
        {
            
            OpenMenu(hydro, hydroTur);
        }
        public void ButtonDieselLogic()
        {
            
            OpenMenu(diesel, dieselGen);
        }
        public void ButtonBiofuelLogic()
        {
            
            OpenMenu(biofuel, bioGen);
        }
        public void ButtonSolarLogic()
        {
            
            OpenMenu(solar, solCluster);
        }
        public void ButtonCoalLogic()
        {
            
            OpenMenu(coal, coalGen);
        }
        public void ButtonWindLogic()
        {
            
            OpenMenu(wind, windFarm);
        }
        public void ButtonNaturalGasLogic()
        {
            
            OpenMenu(naturalGas, natGasGen);
        }
        public void ButtonGeothermalLogic()
        {
            
            OpenMenu(geothermal, geoPlant);
        }
        public void ButtonNuclearLogic()
        {
            
            OpenMenu(nuclear, nuclearPlant);
        }
        public void ButtonAntiLogic()
        {
            
            OpenMenu(anti, antiGen);
        }
        public void ButtonDysonLogic()
        {
            
            OpenMenu(dyson, dysonSphere);
        }
        
    }

public class shopSlot
{
    private EnergyGenerator energygenerator;
    private string name;
    public int count = 0;
    private int storeCost;
    public bool isSelected;

    public shopSlot(EnergyGenerator generator,  int startCount, string name1, bool bought,int cost)
    {
        energygenerator = generator;
        count = startCount;
        name = name1;
        isSelected = bought;
        storeCost = cost;
    }
    public string getName(){
        return name;
    }

    public int getCount(){
        return count;
    }
    public EnergyGenerator GetGenerator()
    {
        return energygenerator;
    }

    public int getPrice(){
        return storeCost;
    }


}