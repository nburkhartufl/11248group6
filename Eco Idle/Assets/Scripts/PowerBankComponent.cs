using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using powergenerators;

namespace powerbankcomponent
{
    public class PowerBankComponent : MonoBehaviour
    {
        [SerializeField]
        private Button slotOne, slotTwo, slotThree, slotFour, slotFive, slotSix, slotSeven, slotEight, slotNine, slotTen, slotEleven, slotTwelve,
            slotThirteen, slotFourteen, slotFifteen, slotSixteen, slotSeventeen, slotEightteen;

        private Dictionary<Button, PowerBankSlot> powerBankSlots = new Dictionary<Button, PowerBankSlot>();

        private bool loadSave;

        private bool saveGame;

        public int testInt = 12;

        // Start is called before the first frame update
        void Start() //Deserialize PowerBank
        {
            InitializeSlots();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitializeSlots()
        {
            powerBankSlots.Add(slotOne, new PowerBankSlot());
            powerBankSlots.Add(slotTwo, new PowerBankSlot());
            powerBankSlots.Add(slotThree, new PowerBankSlot());
            powerBankSlots.Add(slotFour, new PowerBankSlot());
            powerBankSlots.Add(slotFive, new PowerBankSlot());
            powerBankSlots.Add(slotSix, new PowerBankSlot());
            powerBankSlots.Add(slotSeven, new PowerBankSlot());
            powerBankSlots.Add(slotEight, new PowerBankSlot());
            powerBankSlots.Add(slotNine, new PowerBankSlot());
            powerBankSlots.Add(slotTen, new PowerBankSlot());
            powerBankSlots.Add(slotEleven, new PowerBankSlot());
            powerBankSlots.Add(slotTwelve, new PowerBankSlot());
            powerBankSlots.Add(slotThirteen, new PowerBankSlot());
            powerBankSlots.Add(slotFourteen, new PowerBankSlot());
            powerBankSlots.Add(slotFifteen, new PowerBankSlot());
            powerBankSlots.Add(slotSixteen, new PowerBankSlot());
            powerBankSlots.Add(slotSeventeen, new PowerBankSlot());
            powerBankSlots.Add(slotEightteen, new PowerBankSlot());
        }
    }
}
public class PowerBankSlot
{
    
    private EnergyGenerator energyGenerator;

    private bool isLocked;

    private bool isEmpty;

    private int unlockCost;

    public PowerBankSlot()
    {
        isLocked = true;

        isEmpty = true;

        unlockCost = 0;
    }

    public void SetUnlocked()
    {
        isLocked = false;
    }

    public void SetGenerator(EnergyGenerator setGenerator)
    {
        energyGenerator = setGenerator;
    }

    public EnergyGenerator GetGenerator()
    {
        return energyGenerator;
    }

    public bool GetUnlocked()
    {
        return isLocked;
    }

    public bool getEmpty()
    {
        return isEmpty;
    }
}