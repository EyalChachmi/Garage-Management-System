using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class Garage
    {
        private List<Vehicle> m_Vehicles;
        public Garage()
        {
            m_Vehicles = new List<Vehicle>();
        }

        public List<Vehicle> Vehicles
        {
            get
            {
                return m_Vehicles;
            }
        }

        public void AddVehicle(Vehicle i_Vehicle)
        {
            m_Vehicles.Add(i_Vehicle);
        }

        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool vehicleExists = false;

            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicleExists = true;
                }
            }

            return vehicleExists;
        }

        public void ChangeVehicleCondition(string i_LicenseNumber, eVehicleCondition i_NewCondition)
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.VehicleCondition = i_NewCondition;

                    return;
                }
            }
        }

        public void InflatTiresByLicenseNumber(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.TireInflationToMaximumForEachTire();

                    return;
                }
            }
        }

        public void FillEnergyForFueledVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelToAdd)
        {
            Vehicle vehicle = GetVehicleInGarageByLicenseNumber(i_LicenseNumber);

            if (vehicle.VehicleEnergyType is Fuel)
            {
                (vehicle.VehicleEnergyType as Fuel).FillEnergy(i_FuelToAdd, i_FuelType);
                vehicle.EnergyPercent = ((vehicle.VehicleEnergyType as Fuel).CurrentFuelQuantity / (vehicle.VehicleEnergyType as Fuel).MaxFuelQuantity) * 100;
            }
            else
            {
                throw new ArgumentException("The current vehicle does not support fuel");
            }
        }

        public void FillEnergyForBatteryVehicle(string i_LicenseNumber, float i_AmountOfHours)
        {
            Vehicle vehicle = GetVehicleInGarageByLicenseNumber(i_LicenseNumber);

            if (vehicle.VehicleEnergyType is Battery)
            {
                (vehicle.VehicleEnergyType as Battery).FillEnergy(i_AmountOfHours);
                vehicle.EnergyPercent = ((vehicle.VehicleEnergyType as Battery).RemainingBatteryTime / (vehicle.VehicleEnergyType as Battery).MaxBatteryTime)*100;
            }
            else
            {
                throw new ArgumentException("The current vehicle does not support battery");
            }
        }

        public Vehicle GetVehicleInGarageByLicenseNumber(string i_LicenseNumber)
        {
            Vehicle vehicleMatchFound = null;

            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicleMatchFound = vehicle;
                    break;
                }
            }

            if (vehicleMatchFound == null)
            {
                throw new ArgumentException("The license Number does not have an exisiting vehicle that matches it");
            }

            return vehicleMatchFound;
        }
    }
}
