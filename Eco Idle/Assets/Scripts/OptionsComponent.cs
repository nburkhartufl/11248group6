using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using powergenerators;
using counterscomponent;
using powerbankcomponent;
using System.IO;

public class OptionsComponent : MonoBehaviour
{

    public void ResetEnergy()
    {
        FindObjectOfType<CounterComponent>().ResetEnergyCounter();
    }
    public void ResetPollution()
    {
        FindObjectOfType<CounterComponent>().ResetPollutionCounter();
    }
    public void AddEnergy()
    {
        FindObjectOfType<CounterComponent>().SetEnergyPerSecond(100000);
    }
    public void RemoveEnergy()
    {
        if(FindObjectOfType<CounterComponent>().GetEnergyCount() >= 100000)
        {
            FindObjectOfType<CounterComponent>().SubstractEnergyCount(100000);
        }
        else
        {
            FindObjectOfType<CounterComponent>().SubstractEnergyCount(FindObjectOfType<CounterComponent>().GetEnergyCount());
        }
    }

    public void AddPollution()
    {
        FindObjectOfType<CounterComponent>().SetPollutionPerSecond(100000);
    }
    public void RemovePollution()
    {
        if (FindObjectOfType<CounterComponent>().GetPollutionCount() >= 100000)
        {
            FindObjectOfType<CounterComponent>().SubtractPollutionCount(100000);
        }
        else
        {
            FindObjectOfType<CounterComponent>().SubtractPollutionCount(FindObjectOfType<CounterComponent>().GetPollutionCount());
        }
    }

    public void DeleteGame()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("currEnergy", FindObjectOfType<CounterComponent>().GetEnergyCount());
        PlayerPrefs.SetInt("maxEnergy", FindObjectOfType<CounterComponent>().GetMaxEnergyCount());
        PlayerPrefs.SetInt("currPollution", FindObjectOfType<CounterComponent>().GetPollutionCount());
        PlayerPrefs.SetInt("maxPollution", FindObjectOfType<CounterComponent>().GetMaxPollutionCount());
        //Saves Counter Component


        PlayerPrefs.SetInt("pbSlotTwoLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(2)));
        PlayerPrefs.SetInt("pbSlotThreeLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(3)));
        PlayerPrefs.SetInt("pbSlotFourLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(4)));
        PlayerPrefs.SetInt("pbSlotFiveLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(5)));
        PlayerPrefs.SetInt("pbSlotSixLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(6)));
        PlayerPrefs.SetInt("pbSlotSevenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(7)));
        PlayerPrefs.SetInt("pbSlotEightLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(8)));
        PlayerPrefs.SetInt("pbSlotNineLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(9)));
        PlayerPrefs.SetInt("pbSlotTenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(10)));
        PlayerPrefs.SetInt("pbSlotElevenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(11)));
        PlayerPrefs.SetInt("pbSlotTwelveLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(12)));
        PlayerPrefs.SetInt("pbSlotThirteenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(13)));
        PlayerPrefs.SetInt("pbSlotFourteenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(14)));
        PlayerPrefs.SetInt("pbSlotFifteenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(15)));
        PlayerPrefs.SetInt("pbSlotSixteenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(16)));
        PlayerPrefs.SetInt("pbSlotSeventeenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(17)));
        PlayerPrefs.SetInt("pbSlotEightteenLock", BoolToInt(FindObjectOfType<PowerBankComponent>().CheckLockedSlot(18)));
        //PowerBankSlots (Locked/Unlocked)


        FindObjectOfType<PowerBankComponent>().SaveGenerators();
    }

    private int BoolToInt(bool slotLocked)
    {
        if (slotLocked == true)
        {
            return 1;
        }
        else 
        { 
            return 0; 
        }
    }

}
