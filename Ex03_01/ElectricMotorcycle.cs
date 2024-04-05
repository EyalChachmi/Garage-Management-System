using System.Collections.Generic;
using System.Text;

namespace Ex03_01
{
    public class ElectricMotorcycle : Motorcycle
    {
        private Battery m_Battery;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, int i_EngineCapacity, eLicense i_LicenseType, Battery i_Battery) : base(i_ModelName, i_LicenseNumber, i_EngineCapacity, i_LicenseType)
        {
            this.m_Battery = i_Battery;
            m_Battery.MaxBatteryTime = 2.8f;
            for (int i = 0; i < 2; i++)
            {
                m_Tires.Add(new Tire(29));
            }

            base.VehicleEnergyType = i_Battery;
        }

        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, eVehicleCondition i_VehicleCondition, string i_ModelName, int i_EngineCapacity, eLicense i_LicenseType, float i_RemainingBattaryLife)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition, i_ModelName);
            this.m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
            m_Battery.RemainingBatteryTime = i_RemainingBattaryLife;
            m_Battery.MaxBatteryTime = 2.8f;
            m_EnergyPrecent = (m_Battery.RemainingBatteryTime / m_Battery.MaxBatteryTime) * 100;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine(m_Battery.ToString());

            return stringBuilder.ToString();
        }
    }
}
