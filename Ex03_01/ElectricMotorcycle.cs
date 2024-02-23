using System.Collections.Generic;

namespace Ex03_01
{
    public class ElectricMotorcycle : Motorcycle
    {
        private Battery m_Battery;

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, int i_EngineCapacity, eLicense i_LicenseType, Battery i_Battery) : base(i_ModelName, i_LicenseNumber, i_EngineCapacity, i_LicenseType)
        {
            this.m_Battery = i_Battery;
            m_Battery.MaxBatteryTime=2.8f;
            for (int i = 0; i < 2; i++)
            {
                m_Tires.Add(new Tire(29));
            }
            m_EnergyPrecent = (m_Battery.RemainingBatteryTime / m_Battery.MaxBatteryTime) * 100;
        }
        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition, int i_EngineCapacity, eLicense i_LicenseType, float i_RemainingBattaryLife)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
            m_Battery = new Battery(i_RemainingBattaryLife);
        }
    }
}
