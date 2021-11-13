using System.Collections;
using System.Collections.Generic;


namespace powergenerators
{
    abstract public class EnergyGenerator
    {
        //GetUnlock
        protected int pollutionUnlock;
        protected int energyUnlock;

        //GetCost
        protected int storeCost;

        //GetType
        protected string type;

        //GetEnergyRate
        protected int energyRate;

        //GetPreRequisites
        protected List<string> preRequisites = new List<string>();

        public abstract bool GetClean();
        public string GetTypeExplicit()
        {
            return type;
        }
        public int GetEnergyRate()
        {
            return energyRate;
        }
        public virtual int GetPollutionRate()
        {
            return 0;
        }
        public int GetCost()
        {
            return storeCost;
        }
        public List<int> GetUnlock()
        {
            List<int> unlockList = new List<int>();

            unlockList.Add(energyUnlock);
            unlockList.Add(pollutionUnlock);

            return unlockList;
        }
        public List<string> GetPreRequisites()
        {
            return preRequisites;
        }

    }

    abstract class PollutingEnergyGenerator : EnergyGenerator
    {
        //GetPollutionRate
        protected int pollutionRate;

        public override int GetPollutionRate()
        {
            return pollutionRate;
        }
        public override bool GetClean()
        {
            return false;
        }
    }

    abstract class CleanEnergyGenerator : EnergyGenerator
    {
        public override int GetPollutionRate()
        {
            return 0;
        }

        public override bool GetClean()
        {
            return true;
        }
    }

    class FaradayGenerator : CleanEnergyGenerator
    {
        public FaradayGenerator()
        {
            energyRate = 10;

            pollutionUnlock = 0;
            energyUnlock = 0;

            storeCost = 0;

            preRequisites.Add("N/A");

            type = "Faraday Disk";
        }
    }

    class ElectromagneticGenerator : CleanEnergyGenerator
    {
        public ElectromagneticGenerator()
        {
            energyRate = 10;

            pollutionUnlock = 0;
            energyUnlock = 300;

            storeCost = 400;

            preRequisites.Add("Faraday Disk");

            type = "Electromagnetic Dynamo";
        }
    }

    class HydroGenerator : CleanEnergyGenerator
    {
        public HydroGenerator()
        {
            energyRate = 25;

            pollutionUnlock = 2500;
            energyUnlock = 50000;

            storeCost = 65000;

            preRequisites.Add("Electromagnetic Dynamo");

            type = "Hydro Turbine";
        }
    }

    class SolarGenerator : CleanEnergyGenerator
    {
        public SolarGenerator()
        {
            energyRate = 75;

            pollutionUnlock = 35000;
            energyUnlock = 80000;

            storeCost = 100000;

            preRequisites.Add("Hydro Turbine");
            preRequisites.Add("Diesel Generator");

            type = "Solar Cluster";
        }
    }

    class WindGenerator : CleanEnergyGenerator
    {
        public WindGenerator()
        {
            energyRate = 150;

            pollutionUnlock = 50000;
            energyUnlock = 150000;

            storeCost = 180000;

            preRequisites.Add("Biofuel Generator");
            preRequisites.Add("Solar Cluster");

            type = "Wind Farm";
        }
    }

    class GeothermalGenerator : CleanEnergyGenerator
    {
        public GeothermalGenerator()
        {
            energyRate = 600;

            pollutionUnlock = 100000;
            energyUnlock = 350000;

            storeCost = 450000;

            preRequisites.Add("Wind Farm");

            type = "Geothermal Plant";
        }
    }

    class DieselGenerator : PollutingEnergyGenerator
    {
        public DieselGenerator()
        {
            energyRate = 35;
            pollutionRate = 60;

            pollutionUnlock = 0;
            energyUnlock = 36000;

            storeCost = 40000;

            preRequisites.Add("Electromagnetic Dynamo");

            type = "Diesel Generator";
        }
    }

    class CoalGenerator : PollutingEnergyGenerator
    {
        public CoalGenerator()
        {
            energyRate = 90;
            pollutionRate = 90;

            pollutionUnlock = 40000;
            energyUnlock = 40000;

            storeCost = 45000;

            preRequisites.Add("Diesel Generator");

            type = "Coal Generator";
        }
    }

    class BiofuelGenerator : PollutingEnergyGenerator
    {
        public BiofuelGenerator()
        {
            energyRate = 45;
            pollutionRate = 3;

            pollutionUnlock = 2000;
            energyUnlock = 25000;

            storeCost = 25000;

            preRequisites.Add("Hydro Turbine");

            type = "Biofuel Generator";
        }
    }

    class NaturalGasGenerator : PollutingEnergyGenerator
    {
        public NaturalGasGenerator()
        {
            energyRate = 175;
            pollutionRate = 120;

            pollutionUnlock = 60000;
            energyUnlock = 70000;

            storeCost = 90000;

            preRequisites.Add("Coal Generator");
            preRequisites.Add("Solar Cluster");

            type = "Natural Gas Generator";
        }
    }

    class NuclearGenerator : PollutingEnergyGenerator
    {
        public NuclearGenerator()
        {
            energyRate = 4500;
            pollutionRate = 450;

            pollutionUnlock = 10000000;
            energyUnlock = 10000000;

            storeCost = 12000000;

            preRequisites.Add("Natural Gas Generator");

            type = "Nuclear Plant";
        }
    }

    class AntiGenerator : PollutingEnergyGenerator
    {
        public AntiGenerator()
        {
            energyRate = 100000;
            pollutionRate = 100000;

            pollutionUnlock = 90000000;
            energyUnlock = 90000000;

            storeCost = 99999999;

            preRequisites.Add("Nuclear Plant");
            preRequisites.Add("Geothermal Plant");

            type = "Antimatter Generator";
        }
    }

    class DysonGenerator : CleanEnergyGenerator
    {
        public DysonGenerator()
        {
            energyRate = 2147483647;

            pollutionUnlock = 999999999;
            energyUnlock = 999999999;

            storeCost = 999999999;

            preRequisites.Add("Antimatter Generator");

            type = "Dyson Sphere";
        }
    }

}