using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using powergenerators;
using counterscomponent;

namespace powerbankcomponent
{
    public class PowerBankComponent : MonoBehaviour
    {
        [SerializeField]
        private Button slotOne, slotTwo, slotThree, slotFour, slotFive, slotSix, slotSeven, slotEight, slotNine, slotTen, slotEleven, slotTwelve,
            slotThirteen, slotFourteen, slotFifteen, slotSixteen, slotSeventeen, slotEightteen, closeBtn, purchaseBtn;

        [SerializeField]
        private Sprite farDisk, electroGen, hydroTur, solCluster, windFarm, geoPlant, dieselGen, coalGen, bioGen, natGasGen, nuclearPlant, antiGen,
            dysonSphere;

        [SerializeField]
        TextMeshProUGUI powerBankSpace, pollutionPS, energyPS, purchaseUnlock;

        [SerializeField]
        private GameObject lockedMenu;

        private Dictionary<Button, PowerBankSlot> powerBankSlots = new Dictionary<Button, PowerBankSlot>();

        private bool loadSave;
        private bool saveGame;

        private int energyPerSecond = 0;
        private int pollutionPerSecond = 0;
        private int slotsAvailable = 0;
        private int slotsUsed = 0;

        private string currentSlot;

        // Start is called before the first frame update
        void Start() //Deserialize PowerBank
        {
            InitializeSlots();
            InitializeUnlocked();
            InitializeGenerators();
            InvokeRepeating("CalculateEnergyPerSecond", 0, 1);
            InvokeRepeating("CalculatePollutionPerSecond", 0, 1);
            InvokeRepeating("CalculateSlotsUsed", 0, 1);
            InvokeRepeating("UpdateSpriteFamilies", 0, 1);
        }

        void InitializeGenerators()
        {
            if (PlayerPrefs.HasKey("genSlotTwo"))
            {
               powerBankSlots[slotTwo].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotTwo")));
            }
            if (PlayerPrefs.HasKey("genSlotThree"))
            {
                powerBankSlots[slotThree].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotThree")));
            }
            if (PlayerPrefs.HasKey("genSlotFour"))
            {
                powerBankSlots[slotFour].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotFour")));
            }
            if (PlayerPrefs.HasKey("genSlotFive"))
            {
                powerBankSlots[slotFive].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotFive")));
            }
            if (PlayerPrefs.HasKey("genSlotSix"))
            {
                powerBankSlots[slotSix].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotSix")));
            }
            if (PlayerPrefs.HasKey("genSlotSeven"))
            {
                powerBankSlots[slotSeven].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotSeven")));
            }
            if (PlayerPrefs.HasKey("genSlotEight"))
            {
                powerBankSlots[slotEight].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotEight")));
            }
            if (PlayerPrefs.HasKey("genSlotNine"))
            {
                powerBankSlots[slotNine].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotNine")));
            }
            if (PlayerPrefs.HasKey("genSlotTen"))
            {
                powerBankSlots[slotTen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotTen")));
            }
            if (PlayerPrefs.HasKey("genSlotEleven"))
            {
                powerBankSlots[slotEleven].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotEleven")));
            }
            if (PlayerPrefs.HasKey("genSlotTwelve"))
            {
                powerBankSlots[slotTwelve].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotTwelve")));
            }
            if (PlayerPrefs.HasKey("genSlotThirteen"))
            {
                powerBankSlots[slotThirteen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotThirteen")));
            }
            if (PlayerPrefs.HasKey("genSlotFourteen"))
            {
                powerBankSlots[slotFourteen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotFourteen")));
            }
            if (PlayerPrefs.HasKey("genSlotFifteen"))
            {
                powerBankSlots[slotFifteen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotFifteen")));
            }
            if (PlayerPrefs.HasKey("genSlotSixteen"))
            {
                powerBankSlots[slotSixteen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotSixteen")));
            }
            if (PlayerPrefs.HasKey("genSlotSeventeen"))
            {
                powerBankSlots[slotSeventeen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotSeventeen")));
            }
            if (PlayerPrefs.HasKey("genSlotEightteen"))
            {
                powerBankSlots[slotEightteen].SetGenerator(StringToGen(PlayerPrefs.GetString("genSlotEightteen")));
            }

        }
        EnergyGenerator StringToGen(string genName)
        {
            if(genName == "Faraday Disk")
            {
                return new FaradayGenerator();
            }
            else if(genName == "Electromagnetic Dynamo")
            {
                return new ElectromagneticGenerator();
            }
            else if (genName == "Hydro Turbine")
            {
                return new HydroGenerator();
            }
            else if (genName == "Solar Cluster")
            {
                return new SolarGenerator();
            }
            else if (genName == "Wind Farm")
            {
                return new WindGenerator();
            }
            else if (genName == "Geothermal Plant")
            {
                return new GeothermalGenerator();
            }
            else if (genName == "Diesel Generator")
            {
                return new DieselGenerator();
            }
            else if (genName == "Coal Generator")
            {
                return new CoalGenerator();
            }
            else if (genName == "Biofuel Generator")
            {
                return new BiofuelGenerator();
            }
            else if (genName == "Natural Gas Generator")
            {
                return new NaturalGasGenerator();
            }
            else if (genName == "Nuclear Plant")
            {
                return new NuclearGenerator();
            }
            else if (genName == "Antimatter Generator")
            {
                return new AntiGenerator();
            }
            else if (genName == "Dyson Sphere")
            {
                return new DysonGenerator();
            }
            return null;
        }
        void InitializeUnlocked()
        {
            if (PlayerPrefs.HasKey("pbSlotTwoLock"))
            {
                if(PlayerPrefs.GetInt("pbSlotTwoLock") == 0)
                {
                    powerBankSlots[slotTwo].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotThreeLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotThreeLock") == 0)
                {
                    powerBankSlots[slotThree].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotFourLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotFourLock") == 0)
                {
                    powerBankSlots[slotFour].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotFiveLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotFiveLock") == 0)
                {
                    powerBankSlots[slotFive].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotSixLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotSixLock") == 0)
                {
                    powerBankSlots[slotSix].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotSevenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotSevenLock") == 0)
                {
                    powerBankSlots[slotSeven].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotEightLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotEightLock") == 0)
                {
                    powerBankSlots[slotEight].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotNineLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotNineLock") == 0)
                {
                    powerBankSlots[slotNine].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotTenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotTenLock") == 0)
                {
                    powerBankSlots[slotTen].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotElevenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotElevenLock") == 0)
                {
                    powerBankSlots[slotEleven].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotTwelveLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotTwelveLock") == 0)
                {
                    powerBankSlots[slotTwelve].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotThirteenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotThirteenLock") == 0)
                {
                    powerBankSlots[slotThirteen].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotFourteenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotFourteenLock") == 0)
                {
                    powerBankSlots[slotFourteen].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotFifteenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotFifteenLock") == 0)
                {
                    powerBankSlots[slotFifteen].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotSixteenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotSixteenLock") == 0)
                {
                    powerBankSlots[slotSixteen].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotSeventeenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotSeventeenLock") == 0)
                {
                    powerBankSlots[slotSeventeen].SetUnlocked();
                }
            }
            if (PlayerPrefs.HasKey("pbSlotEightteenLock"))
            {
                if (PlayerPrefs.GetInt("pbSlotEightteenLock") == 0)
                {
                    powerBankSlots[slotEightteen].SetUnlocked();
                }
            }
        }

        void InitializeSlots()
        {
            PowerBankSlot firstSlot = new PowerBankSlot(0);
            firstSlot.SetGenerator(new FaradayGenerator());
            firstSlot.SetUnlocked();

            powerBankSlots.Add(slotOne, firstSlot);
            powerBankSlots.Add(slotTwo, new PowerBankSlot(100));
            powerBankSlots.Add(slotThree, new PowerBankSlot(5000));
            powerBankSlots.Add(slotFour, new PowerBankSlot(25000));
            powerBankSlots.Add(slotFive, new PowerBankSlot(50000));
            powerBankSlots.Add(slotSix, new PowerBankSlot(100000));
            powerBankSlots.Add(slotSeven, new PowerBankSlot(500000));
            powerBankSlots.Add(slotEight, new PowerBankSlot(500000));
            powerBankSlots.Add(slotNine, new PowerBankSlot(500000));
            powerBankSlots.Add(slotTen, new PowerBankSlot(500000));
            powerBankSlots.Add(slotEleven, new PowerBankSlot(1000000));
            powerBankSlots.Add(slotTwelve, new PowerBankSlot(1000000));
            powerBankSlots.Add(slotThirteen, new PowerBankSlot(2000000));
            powerBankSlots.Add(slotFourteen, new PowerBankSlot(2000000));
            powerBankSlots.Add(slotFifteen, new PowerBankSlot(3000000));
            powerBankSlots.Add(slotSixteen, new PowerBankSlot(3000000));
            powerBankSlots.Add(slotSeventeen, new PowerBankSlot(10000000));
            powerBankSlots.Add(slotEightteen, new PowerBankSlot(10000000));
        }

        public int GetEnergyPerSecond()
        {
            return energyPerSecond;
        }

        public int GetPollutionPerSecond()
        {
            return pollutionPerSecond;
        }

        public void CalculateEnergyPerSecond()
        {
            energyPerSecond = 0;
            foreach(KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (!entry.Value.GetEmpty())
                {
                    //CounterComponent.energyPerSecond
                    energyPerSecond = energyPerSecond + entry.Value.GetGenerator().GetEnergyRate();
                }
            }

        }

        public void CalculatePollutionPerSecond()
        {
            pollutionPerSecond = 0;
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                //if(entry.Value.GetType() == typeof(PollutingEnergyGenerator))
                //{
                if (!entry.Value.GetEmpty())
                {
                    pollutionPerSecond = pollutionPerSecond + entry.Value.GetGenerator().GetPollutionRate();
                }
            }
            UpdatePerSecond();
        }

        public void CalculateSlotsUsed()
        {
            slotsUsed = 0;
            slotsAvailable = 0;

            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (!entry.Value.GetLocked())
                {
                    slotsAvailable = slotsAvailable + 1;
                    if (!entry.Value.GetEmpty())
                    {
                        slotsUsed = slotsUsed + 1;
                    }
                }
            }
        }

        public int GetSlotsUsed()
        {
            return slotsUsed;
        }

        public int GetSlotsAvailable()
        {
            return slotsAvailable;
        }

        protected void UpdatePerSecond()
        {
            energyPS.text = "ENERGY PER SECOND: " + GetEnergyPerSecond().ToString();
            FindObjectOfType<CounterComponent>().SetEnergyPerSecond(energyPerSecond);
            pollutionPS.text = "POLLUTION PER SECOND: " + GetPollutionPerSecond().ToString();
            FindObjectOfType<CounterComponent>().SetPollutionPerSecond(pollutionPerSecond);
            powerBankSpace.text = "POWER BANK SPACE USED: " + GetSlotsUsed() + "/" + GetSlotsAvailable() ;
        }

        public void AddGenerator(EnergyGenerator addGenerator)
        {
            bool added = false;

            foreach(KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if(entry.Value.GetEmpty() && !entry.Value.GetLocked() && !added)
                {
                    entry.Value.SetGenerator(addGenerator);
                    added = true;
                }
            }

 
        }
        public void SaveGenerators()
        {
            int counter = 1;
            foreach(KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if(counter == 2)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotTwo", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 3)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotThree", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 4)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        Debug.Log("Made it Here");
                        PlayerPrefs.SetString("genSlotFour", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 5)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotFive", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 6)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotSix", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 7)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotSeven", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 8)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotEight", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 9)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotNine", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 10)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotTen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 11)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotEleven", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 12)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotTwelve", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 13)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotThirteen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 14)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotFourteen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 15)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotFifteen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 16)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotSixteen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 17)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotSeventeen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                else if (counter == 18)
                {
                    if (!entry.Value.GetEmpty())
                    {
                        PlayerPrefs.SetString("genSlotEightteen", entry.Value.GetGenerator().GetTypeExplicit());
                    }
                }
                counter++;
            }
        }
        
        public bool CheckLockedSlot(int slot)
        {
            switch (slot)
            {
                case 1:
                    break;
                case 2:
                    return powerBankSlots[slotTwo].GetLocked();
                    break;
                case 3:
                    return powerBankSlots[slotThree].GetLocked();
                    break;
                case 4:
                    return powerBankSlots[slotFour].GetLocked();
                    break;
                case 5:
                    return powerBankSlots[slotFive].GetLocked();
                    break;
                case 6:
                    return powerBankSlots[slotSix].GetLocked();
                    break;
                case 7:
                    return powerBankSlots[slotSeven].GetLocked();
                    break;
                case 8:
                    return powerBankSlots[slotEight].GetLocked();
                    break;
                case 9:
                    return powerBankSlots[slotNine].GetLocked();
                    break;
                case 10:
                    return powerBankSlots[slotTen].GetLocked();
                    break;
                case 11:
                    return powerBankSlots[slotEleven].GetLocked();
                    break;
                case 12:
                    return powerBankSlots[slotTwelve].GetLocked();
                    break;
                case 13:
                    return powerBankSlots[slotThirteen].GetLocked();
                    break;
                case 14:
                    return powerBankSlots[slotFourteen].GetLocked();
                    break;
                case 15:
                    return powerBankSlots[slotFifteen].GetLocked();
                    break;
                case 16:
                    return powerBankSlots[slotSixteen].GetLocked();
                    break;
                case 17:
                    return powerBankSlots[slotSeventeen].GetLocked();
                    break;
                case 18:
                    return powerBankSlots[slotEightteen].GetLocked();
                    break;
                default:
                    break;
            }

            return false;
        }

        public void UpdateSpriteFamilies()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (!entry.Value.GetLocked())
                {
                    entry.Key.transform.Find("locked").gameObject.SetActive(false);
                    
                    if (!entry.Value.GetEmpty())
                    {
                        entry.Key.transform.Find("unlocked").gameObject.SetActive(true);

                        if (entry.Value.GetGenerator().GetType() == typeof(FaradayGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = farDisk;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(ElectromagneticGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = electroGen;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(HydroGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = hydroTur;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(SolarGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = solCluster;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(WindGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = windFarm;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(GeothermalGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = geoPlant;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(DieselGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = dieselGen;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(CoalGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = coalGen;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(BiofuelGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = bioGen;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(NaturalGasGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = natGasGen;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(NuclearGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = nuclearPlant;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(AntiGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = antiGen;
                        }

                        else if (entry.Value.GetGenerator().GetType() == typeof(DysonGenerator))
                        {
                            entry.Key.transform.Find("unlocked").transform.Find("generator").GetComponent<Image>().sprite = dysonSphere;
                        }
                    }
                }
            }
        }

        public void OpenLockedMenu(KeyValuePair<Button, PowerBankSlot> entry, string currentSlotName)
        {
            lockedMenu.SetActive(true);
            currentSlot = currentSlotName;


            purchaseUnlock.text = entry.Value.GetUnlockCost().ToString();
        }

        public void CloseLockedMenu()
        {
            lockedMenu.SetActive(false);
        }

        public void PurchaseSlot()
        {
            foreach(KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if(entry.Key.name.ToString() == currentSlot && FindObjectOfType<CounterComponent>().GetEnergyCount() >= entry.Value.GetUnlockCost())
                {
                    FindObjectOfType<CounterComponent>().SubstractEnergyCount(entry.Value.GetUnlockCost());
                    entry.Value.SetUnlocked();
                    lockedMenu.SetActive(false);
                }
            }
        }

        public void ButtonSlotOneLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotOne")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotOne");
                    }
                }
            }
        }
        public void ButtonSlotTwoLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotTwo")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotTwo");
                    }
                }
            }
        }
        public void ButtonSlotThreeLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotThree")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotThree");
                    }
                }
            }
        }
        public void ButtonSlotFourLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotFour")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotFour");
                    }
                }
            }
        }
        public void ButtonSlotFiveLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotFive")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotFive");
                    }
                }
            }
        }
        public void ButtonSlotSixLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotSix")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotSix");
                    }
                }
            }
        }
        public void ButtonSlotSevenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotSeven")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotSeven");
                    }
                }
            }
        }
        public void ButtonSlotEightLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotEight")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotEight");
                    }
                }
            }
        }
        public void ButtonSlotNineLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotNine")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotNine");
                    }
                }
            }
        }
        public void ButtonSlotTenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotTen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotTen");
                    }
                }
            }
        }
        public void ButtonSlotElevenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotEleven")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotEleven");
                    }
                }
            }
        }
        public void ButtonSlotTwelveLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotTwelve")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotTwelve");
                    }
                }
            }
        }
        public void ButtonSlotThirteenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotThirteen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotThirteen");
                    }
                }
            }
        }

        public void ButtonSlotFourteenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotFourteen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotFourteen");
                    }
                }
            }
        }

        public void ButtonSlotFifteenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotFifteen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotFifteen");
                    }
                }
            }
        }

        public void ButtonSlotSixteenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotSixteen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotSixteen");
                    }
                }
            }
        }

        public void ButtonSlotSeventeenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotSeventeen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotSeventeen");
                    }
                }
            }
        }

        public void ButtonSlotEightteenLogic()
        {
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if (entry.Key.name.ToString() == "slotEightteen")
                {
                    if (entry.Value.GetLocked())
                    {
                        OpenLockedMenu(entry, "slotEightteen");
                    }
                }
            }
        }

    }
}
public class PowerBankSlot
{
    
    private EnergyGenerator energyGenerator;

    private bool isLocked;

    private bool isEmpty;

    private int unlockCost;

    public PowerBankSlot(int uCost)
    {
        isLocked = true;

        isEmpty = true;

        unlockCost = uCost;
    }

    public void SetUnlocked()
    {
        isLocked = false;
    }

    public int GetUnlockCost()
    {
        return unlockCost;
    }

    public void SetGenerator(EnergyGenerator setGenerator)
    {
        energyGenerator = setGenerator;
        isEmpty = false;
    }

    public EnergyGenerator GetGenerator()
    {
        return energyGenerator;
    }

    public bool GetLocked()
    {
        return isLocked;
    }

    public bool GetEmpty()
    {
        return isEmpty;
    }
}