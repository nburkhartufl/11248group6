using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using powergenerators;
using counterscomponent;
using generatortypes;

namespace shopcomponent{
    public class ShopComponent : MonoBehaviour
    {

        [SerializeField]
        private Button faraday, electromagnetic, hydro, solar, wind, geothermal, diesel, coal,
            biofuel, naturalGas, nuclear, anti, dyson, closeBtn, purchaseBtn;

        [SerializeField]
        private Sprite farDisk, electroGen, hydroTur, solCluster, windFarm, geoPlant, dieselGen, coalGen, bioGen, natGasGen, nuclearPlant, antiGen,
            dysonSphere, unlock, lockImg;
        
        [SerializeField]
        private TextMeshProUGUI requirements, description, maxCounter;

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
            foreach(KeyValuePair<Button, shopSlot> entry in shopSlots)
            {
               
            }
        }
        public void OpenMenu(Button butt, Sprite img)
        {
            menu.transform.Find("generatorImage").GetComponent<Image>().sprite = img;

            int energyText = shopSlots[butt].GetGenerator().GetUnlock()[0];
            int pollutionText = shopSlots[butt].GetGenerator().GetUnlock()[1];
            requirements.text = "ENERGY REQUIREMENT: " + energyText + "\nPOLLUTION REQUIREMENT: " + pollutionText;
            menu.SetActive(true);
        }

        void InitializeSlots()
        {
            shopSlots.Add(faraday, new shopSlot(new FaradayGenerator(), 1));
            shopSlots.Add(electromagnetic, new shopSlot(new ElectromagneticGenerator(), 0));
            shopSlots.Add(hydro, new shopSlot(new HydroGenerator(), 0));
            shopSlots.Add(solar, new shopSlot(new SolarGenerator(), 0));
            shopSlots.Add(wind, new shopSlot(new WindGenerator(), 0));
            shopSlots.Add(geothermal, new shopSlot(new GeothermalGenerator(), 0));
            shopSlots.Add(diesel, new shopSlot(new DieselGenerator(), 0));
            shopSlots.Add(coal, new shopSlot(new CoalGenerator(), 0));
            shopSlots.Add(biofuel, new shopSlot(new BiofuelGenerator(), 0));
            shopSlots.Add(naturalGas, new shopSlot(new NaturalGasGenerator(), 0));
            shopSlots.Add(nuclear, new shopSlot(new NuclearGenerator(), 0));
            shopSlots.Add(anti, new shopSlot(new AntiGenerator(), 0));
            shopSlots.Add(dyson, new shopSlot(new DysonGenerator(), 0));
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
}
public class shopSlot
{
    private EnergyGenerator energygenerator;
    private int count = 0;

    public shopSlot(EnergyGenerator generator,  int startCount)
    {
        energygenerator = generator;
        count = startCount;
    }

    public int getCount(){
        return count;
    }
    public EnergyGenerator GetGenerator()
    {
        return energygenerator;
    }


}