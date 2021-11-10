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
            
            InvokeRepeating("CalculateEnergyPerSecond", 0, 1);
            InvokeRepeating("CalculatePollutionPerSecond", 0, 1);
            InvokeRepeating("CalculateSlotsUsed", 0, 1);
            InvokeRepeating("UpdateSpriteFamilies", 0, 1);
        }

        // Update is called once per frame
        void Update()
        {
            
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
<<<<<<< Updated upstream
=======
                    //CounterComponent.energyPerSecond
>>>>>>> Stashed changes
                    energyPerSecond = energyPerSecond + entry.Value.GetGenerator().GetEnergyRate();
                }
            }

<<<<<<< Updated upstream
            UpdatePerSecond();
=======
>>>>>>> Stashed changes
        }

        public void CalculatePollutionPerSecond()
        {
            pollutionPerSecond = 0;
            foreach (KeyValuePair<Button, PowerBankSlot> entry in powerBankSlots)
            {
                if(entry.Value.GetType() == typeof(PollutingEnergyGenerator))
                {
                    pollutionPerSecond = pollutionPerSecond + entry.Value.GetGenerator().GetEnergyRate();
                }
            }
<<<<<<< Updated upstream
=======
            UpdatePerSecond();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            pollutionPS.text = "POLLUTION PER SECOND: " + GetPollutionPerSecond().ToString();
=======
            FindObjectOfType<CounterComponent>().SetEnergyPerSecond(energyPerSecond);
            pollutionPS.text = "POLLUTION PER SECOND: " + GetPollutionPerSecond().ToString();
            FindObjectOfType<CounterComponent>().SetPollutionPerSecond(pollutionPerSecond);
>>>>>>> Stashed changes
            powerBankSpace.text = "POWER BANK SPACE USED: " + GetSlotsUsed() + "/" + GetSlotsAvailable() ;
        }

        public bool AddGenerator(EnergyGenerator addGenerator)
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

            return added;
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