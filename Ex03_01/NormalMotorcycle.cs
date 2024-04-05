using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class NormalMotorcycle : Motorcycle
    {
        private Fuel m_Fuel;

        public NormalMotorcycle(string i_ModelName, string i_LicenseNumber, int i_EngineCapacity, eLicense i_LicenseType, Fuel i_Fuel) : base(i_ModelName, i_LicenseNumber, i_EngineCapacity, i_LicenseType)
        {

            this.m_Fuel = i_Fuel;
            m_Fuel.MaxFuelQuantity = 5.8f;
            m_Fuel.FuelType = eFuelType.Octan98;
            for (int i = 0; i < 2; i++)
            {
                m_Tires.Add(new Tire(29));
            }

            base.VehicleEnergyType = i_Fuel;
        }

        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, eVehicleCondition i_VehicleCondition, string i_ModelName, int i_EngineCapacity, eLicense i_LicenseType, float i_CurrentFuel)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition, i_ModelName);
            this.m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
            m_Fuel.CurrentFuelQuantity = i_CurrentFuel;
            m_Fuel.MaxFuelQuantity = 5.8f;
            m_Fuel.FuelType = eFuelType.Octan98;
            m_EnergyPrecent = (m_Fuel.CurrentFuelQuantity / m_Fuel.MaxFuelQuantity) * 100;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine(m_Fuel.ToString());

            return stringBuilder.ToString();
        }
    }
}
