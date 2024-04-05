using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class ElectricCar : Car
    {
        private Battery m_Battery;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, eCarColor i_Color, eCarDoor i_NumberOfDoors, Battery i_Battery) : base(i_ModelName, i_LicenseNumber, i_Color, i_NumberOfDoors)
        {
            this.m_Battery = i_Battery;
            m_Battery.MaxBatteryTime = 4.8f;
            for (int i = 0; i < 5; i++)
            {
                m_Tires.Add(new Tire(30));
            }

            base.VehicleEnergyType = i_Battery;
        }

        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, eVehicleCondition i_VehicleCondition, string i_ModelName, eCarColor i_CarColor, eCarDoor i_NumberOfDoors, float i_RemainingBattaryLife)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition, i_ModelName);
            this.m_CarColor = i_CarColor;
            this.m_CarDoor = i_NumberOfDoors;
            m_Battery.RemainingBatteryTime = i_RemainingBattaryLife;
            m_Battery.MaxBatteryTime = 4.8f;
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
