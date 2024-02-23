using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class NormalMotorcycle:Motorcycle
    {
        private Fuel m_Fuel;

        public NormalMotorcycle(string i_ModelName, string i_LicenseNumber, int i_EngineCapacity, eLicense i_LicenseType, Fuel i_Fuel) : base(i_ModelName, i_LicenseNumber, i_EngineCapacity, i_LicenseType)
        {
            
            this.m_Fuel= i_Fuel;
            m_Fuel.MaxFuelQuantity = 5.8f;
            m_Fuel.FuelType = eFuelType.Octan98;
            for (int i = 0; i < 2; i++)
            {
                m_Tires.Add(new Tire(29));
            }
            m_EnergyPrecent = (m_Fuel.CurrentFuelQuantity / m_Fuel.MaxFuelQuantity) * 100;
        }
        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition, int i_EngineCapacity, eLicense i_LicenseType, float i_CurrentFuel)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
            m_Fuel = new Fuel(i_CurrentFuel);
        }

    }
}
